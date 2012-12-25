using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mastermind
{
	/// <summary>
	/// Summary description for ComunicacaoClassica.
	/// </summary>
	public class ComunicacaoClassica
	{

		private const String USERNAME = "0 ";
		private const String TABCODIGO = "1 ";
		private const String TABSCORE = "2 ";
		private const String NUMJOGOS = "3 ";

		private bool ligado = false;
		private Socket cliente;		
		private String username = "";
		private int numCom;
		private SolidBrush[] codigo = new SolidBrush[4];
		private SolidBrush[,] tabuleiro = new SolidBrush[12,4];
		private SolidBrush[,] tabScore = new SolidBrush[12,4];
		private bool codRecebido = false;		
		private bool fechou = false;
		private bool jogosRecebidos = false;
		private int nJogos;
		private int pontuacao;
		private bool recebeuUsername = false;
		private System.Threading.Thread t1;

		public ComunicacaoClassica()
		{
			//
			// TODO: Add constructor logic here
			//
		}//construtor

		public void reiniciar()
		{
			Tabuleiro tab = new Tabuleiro();
			TabuleiroScore ts = new TabuleiroScore();
			codigo = new SolidBrush[4];
			tabuleiro = tab.getTabuleiro();
			tabScore = ts.getTabScore();
			codRecebido = false;
			recebeuUsername = false;
		}//reiniciar

		public void servidorClassico()
		{
			Socket m_listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			m_listenSocket.Bind(new IPEndPoint(IPAddress.Any, 8758));
			m_listenSocket.Listen((int)SocketOptionName.MaxConnections);
			cliente = m_listenSocket.Accept();

			if (cliente != null)
			{
				if (cliente.Connected)
				{
					// ligacao estabelecida
					ligado = true;
					t1 = new System.Threading.Thread(new System.Threading.ThreadStart(receiveLoop));
					t1.Start();
				}
				m_listenSocket.Close();
			}
		}//servidorClassico

		public void clienteClassico(String endereco, int porto)
		{
			EndPoint l_EndPoint = new IPEndPoint(IPAddress.Parse(endereco),
				Convert.ToInt16(porto));

			try 
			{
				cliente = new Socket(AddressFamily.InterNetwork, 
					SocketType.Stream, 
					ProtocolType.Tcp);
				cliente.Connect(l_EndPoint);
				if (cliente.Connected)
				{
					ligado = true;
					t1 = new System.Threading.Thread(new System.Threading.ThreadStart(receiveLoop));
					t1.Start();
				}				
			}
			catch (SocketException)
			{
				//MessageBox.Show(ex.ToString());
			}
		}//clienteClassico

		private void receiveLoop()
		{
			try 
			{
				Byte[] l_Buffer;
				string l_receivedString;
				while (cliente.Connected)
				{
					l_Buffer = new Byte[100];
					cliente.Receive(l_Buffer, l_Buffer.Length, SocketFlags.None);
					l_receivedString = System.Text.Encoding.ASCII.GetString(l_Buffer, 0, l_Buffer.Length);					
					myDelegate updateDelegate = new myDelegate(updateMessageLog);
					updateDelegate(l_receivedString);
				}			
			}
			catch (System.Exception)
			{
				//MessageBox.Show(e.ToString());
			}
		}//receiveLoop

		private void updateMessageLog(String str)
		{
			//processar o cabeçalho da mensagem
			StringTokenizer st = new StringTokenizer(str);
			String temp = st.NextToken();
			numCom = Convert.ToInt32(temp);			
			
			switch (numCom)
			{
				case 0 : 
				{		
					//caso em que recebe o username
					username = str.Substring(2,str.Length-2);
					recebeuUsername = true;		
					fechou = false;					
					break;
				}
				case 1 :
				{					
					//caso em que recebe o codigo secreto					
					tabuleiro = paraBrush(str.Substring(2,str.Length-2));
					codRecebido = true;
					break;
				}
				case 2 :
				{
					//caso receba a classificação da sua jogada
                  	tabScore = paraBrush(str.Substring(2,str.Length-2));
					codRecebido = true;
					break;

				}
				case 3 :
				{
					nJogos = Convert.ToInt32(str.Substring(2,str.Length-2));
					jogosRecebidos = true;
					break;
				}			
				default:break;
			}			
		}//updateMessageLog
		
		private delegate void myDelegate(String str);

		private String paraString(SolidBrush[,] sb)
		{
			String result = "";
			for(int j=0; j<12; j++)
			{ 
				for(int i=0; i<4; i++)
				{
					if(sb[j,i].Color.Equals(Color.Blue)) result += "1" + " "; 
					if(sb[j,i].Color.Equals(Color.Red)) result += "2" + " "; 
					if(sb[j,i].Color.Equals(Color.Green)) result += "3" + " ";  
					if(sb[j,i].Color.Equals(Color.Yellow)) result += "4" + " "; 
					if(sb[j,i].Color.Equals(Color.DarkOrange)) result += "5" + " "; 
					if(sb[j,i].Color.Equals(Color.Pink)) result += "6" + " "; 
					if(sb[j,i].Color.Equals(Color.Black)) result += "7" + " "; 
					if(sb[j,i].Color.Equals(Color.White)) result += "8" + " "; 
					if(sb[j,i].Color.Equals(Color.Gray)) result += "9" + " "; 				
				}			
			}
			return result;
		}//paraString

		private SolidBrush[,] paraBrush(String str) 
		{				
			SolidBrush[,] result = new SolidBrush[12,4];
			StringTokenizer st = new StringTokenizer(str);
			for(int j=0; j<12; j++)
			{
				for(int i=0; i<4; i++)
				{	
					String temp = st.NextToken();				
					result[j,i] = paraCor(Convert.ToInt32(temp));
				}			
			}
			return result;
		}//paraBrush

		private SolidBrush paraCor(int indice) 
		{
			SolidBrush result;
			result = Tabuleiro.GetBrush(indice);
			return result;
		}//paraCor

		public bool getFechou()
		{
			return fechou;
		}//getFechou

		public int getNJogos()
		{
			return nJogos;
		}//getNJogos

		public bool getJogosRecebidos()
		{
			return jogosRecebidos;
		}//getJogosRecebidos

		public Socket getSocket()
		{
			return cliente;
		}//getSocket

		public bool userRecebido()
		{
			return recebeuUsername;
		}//userRecebido

		public bool getCodRecebido() 
		{		
			return codRecebido;
		}//getCodRecebido

		public SolidBrush[,] getTabuleiro()
		{
			return tabuleiro;
		}//getTabuleiro

		public SolidBrush[,] getTabScore()
		{
			return tabScore;
		}//getTabScore

		public String getUsername()
		{
			return username;
		}//getUsername

		public void falsoRecebido() 
		{
			codRecebido = false;
		}//falsoRecebido

		public void enviarUsername(String username)
		{
			if(ligado) 
			{
				cliente.Send(System.Text.Encoding.ASCII.GetBytes(USERNAME + username));								
			}
		}//enviarUsername

		public void enviarTabCodigo(SolidBrush[,] codigo)
		{
			if(ligado) 
			{
				String str = paraString(codigo);
				cliente.Send(System.Text.Encoding.ASCII.GetBytes(TABCODIGO + str));				
			}			
		}//enviarTabCodigo

		public void enviarTabScore(SolidBrush[,] codigo)
		{
			if(ligado) 
			{
				String str = paraString(codigo);
				cliente.Send(System.Text.Encoding.ASCII.GetBytes(TABSCORE + str));				
			}
		}//enviarTabScore		

		public void enviarNJogos(int nJogos)
		{
			cliente.Send(System.Text.Encoding.ASCII.GetBytes(NUMJOGOS + nJogos.ToString()));			
		}//enviarNJogos

		public void fechaLigacao()
		{
			cliente.Close();			
		}//fechaLigacao		
	}
}
