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
	/// Summary description for Comunicacao.
	/// </summary>
	public class Comunicacao
	{
		private bool ligado = false;
		private Socket cliente;		
		private String username;
		private int numCom;
		private SolidBrush[] codigo = new SolidBrush[4];
		private bool codRecebido = false;
		private bool terminou = false;
		private bool fechou = false;
		private int pontuacao;
		private System.Threading.Thread t1;

		public Comunicacao()
		{
			//
			// TODO: Add constructor logic here
			//
		}//construtor

		public Comunicacao(Socket s)
		{
			cliente = s;
		}//construtor

		public void servidorSimultaneo()
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
		}//servidorSimultaneo

		public void clienteSimultaneo(String endereco, int porto)
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
		}//clienteSimultaneo

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
					fechou = false;
					terminou = false;
					break;
				}
				case 1 :
				{					
					//caso em que recebe o codigo secreto
					codigo = paraBrush(str.Substring(2,str.Length-2));									
					codRecebido = true;										
					break;
				}
				case 2 :
				{					
					//caso em que recebe a pontuacao final
					pontuacao = Convert.ToInt32(str.Substring(2,str.Length-2));
					terminou = true;				
					break;
				}			
				case 3 : 
				{					
					//caso em que quer fechar o socket
					fechou = true;				
					codRecebido = false;										
					break;
				}
				default:break;
			}			
		}//updateMessageLog

		private String paraString(SolidBrush[] sb)
		{
			String result = "";
			for(int i=0; i<4; i++)
			{
				if(sb[i].Color.Equals(Color.Blue)) result += "1" + " "; 
				if(sb[i].Color.Equals(Color.Red)) result += "2" + " "; 
				if(sb[i].Color.Equals(Color.Green)) result += "3" + " ";  
				if(sb[i].Color.Equals(Color.Yellow)) result += "4" + " "; 
				if(sb[i].Color.Equals(Color.DarkOrange)) result += "5" + " "; 
				if(sb[i].Color.Equals(Color.Pink)) result += "6" + " "; 
				if(sb[i].Color.Equals(Color.Black)) result += "7" + " "; 
				if(sb[i].Color.Equals(Color.White)) result += "8" + " "; 
				if(sb[i].Color.Equals(Color.Gray)) result += "9" + " "; 				
			}			
			return result;
		}//paraString

		private SolidBrush[] paraBrush(String str) 
		{				
			SolidBrush[] result = new SolidBrush[4];
			StringTokenizer st = new StringTokenizer(str);
			for(int i=0; i<4; i++)
			{	
				String temp = st.NextToken();				
				result[i] = paraCor(Convert.ToInt32(temp));
			}			
			return result;
		}//paraBrush

		private SolidBrush paraCor(int indice) 
		{
			SolidBrush result;
			result = Tabuleiro.GetBrush(indice);
			return result;
		}//paraCor

		public String getUsername()
		{
			return username;
		}//getUsername

		public SolidBrush[] getCodigo()
		{
			return codigo;
		}//getCodigo

		public int getPontuacao()
		{
			return pontuacao;
		}//getPontuacao

		public bool getCodRecebido() 
		{
			return codRecebido;
		}//getCodRecebido

		public bool getTerminou()
		{
			return terminou;
		}//getTerminou

		public bool getFechou()
		{
			return fechou;
		}//getFechou

		public Socket getSocket()
		{
			return cliente;
		}//getSocket

		private delegate void myDelegate(String str);

		public void enviarUsername(String username)
		{
			if(ligado) 
			{
				cliente.Send(System.Text.Encoding.ASCII.GetBytes("0 " + username));				
			}
		}//enviarUsername

		public void enviarCodigo(SolidBrush[] codigo)
		{
			if(ligado) 
			{
				String str = paraString(codigo);
				cliente.Send(System.Text.Encoding.ASCII.GetBytes("1 " + str));				
			}
		}//enviarCodigo

		public void enviarPontuacao(int pontuacao)
		{
			cliente.Send(System.Text.Encoding.ASCII.GetBytes("2 " + pontuacao.ToString()));				
		}//enviarPontuacao

		public void enviarTerminar(int terminar)
		{
			cliente.Send(System.Text.Encoding.ASCII.GetBytes("3 " + terminar.ToString()));				
		}//enviarTerminar

		public void fechaLigacao()
		{
			cliente.Close();			
		}//fechaLigacao
	}
}
