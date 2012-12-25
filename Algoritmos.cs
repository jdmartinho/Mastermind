using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Mastermind
{
	/// <summary>
	/// Summary description for Algoritmos.
	/// </summary>
	public class Algoritmos
	{
		public Algoritmos()
		{
			//
			// TODO: Add constructor logic here
			//
		}//construtor

		public SolidBrush[] comparaCodigo(SolidBrush[] codSecreto, SolidBrush[] jogada)
		{
			SolidBrush[] result = new SolidBrush[4];
			int index = 0;
			int brancos = 0;

			for(int i=0; i<4; i++)
			{				
				if(jogada[i].Color.Equals(codSecreto[i].Color)) 
				{
					result[index++] = new SolidBrush(Color.Black);					
				}
				else if(checkBrancos(jogada[i], codSecreto)) 
				{
					brancos++;			
				}
			}
			for(int i=index; i<4; i++) 
			{
				if(brancos > 0) 
				{
					result[i] = new SolidBrush(Color.White);
					brancos--;
				}
				else result[i] = new SolidBrush(Color.Gray);
			}
			return result;
		}//comparaCodigo

		private bool checkBrancos(SolidBrush sb, SolidBrush[] jogada) 
		{
			for(int i=0; i<4; i++) 
			{
				if(jogada[i].Color.Equals(sb.Color)) return true;
			}
			return false;
		}//checkBrancos

		public bool ehFinal(SolidBrush[] sb)
		{
			for(int i=0;i<4;i++)
			{
				if(!sb[i].Color.Equals(Color.Black))
				{
					return false;
				}
			}
			return true;
		}//ehFinal

		public bool ehValido(SolidBrush[] sb)
		{
			for(int i=0;i<4;i++)
			{
				if(sb[i].Color.Equals(Color.Black))
				{
					return false;
				}
			}
			return true;
		}//ehValido
	}
}
