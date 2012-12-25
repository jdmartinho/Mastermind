using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Mastermind
{
	/// <summary>
	/// Summary description for Tabuleiro.
	/// </summary>
	public class Tabuleiro
	{

		private SolidBrush[,] tab;
		private Rectangle bola;
		private const int INICIALX = 41;
		private const int INICIALY = 10;
		private const int ALTURA = 13;
		private const int LARGURA = 13;
		private int posicaoX;
		private int posicaoY;

		public Tabuleiro()
		{
			tab = new SolidBrush[12,4];
			for(int i = 0;i<12;i++)
			{
				for(int j = 0;j<4;j++)
				{
					tab[i,j] = new SolidBrush(Color.Black);
				}
			}					
		}//construtor

		public void pintaLinha(int linha, SolidBrush[] jogada)
		{
			if(linha<12)
			{
				for(int j = 0; j<4;j++)
				{
					tab[linha,j] = jogada[j];
				}
			}		
		}//pintaLinha

		public void Draw(Graphics graphicsObject)
		{
			Pen p = new Pen(Color.Black);
			Brush br;

			posicaoX = INICIALX;
			posicaoY = INICIALY;

			for(int i = 0;i<12;i++)
			{
				for(int j = 0;j<4;j++)
				{					
					bola = new Rectangle(posicaoX,posicaoY,LARGURA,ALTURA);
					br = tab[i,j];
					graphicsObject.DrawEllipse(p,bola);
					graphicsObject.FillEllipse(br,bola);
					posicaoX += 20;					
				}
				posicaoX = INICIALX;
				posicaoY += 16;
			}		
		}//Draw

		public void setTabuleiro(SolidBrush[,] sbs)
		{
			this.tab = sbs;
		}//setTabuleiro

		public static SolidBrush GetBrush(int index)
		{
			SolidBrush br = new SolidBrush(Color.Black);
			switch (index)
			{
				case 1:
					br = new SolidBrush(Color.Blue);
					break;
				case 2:
					br = new SolidBrush(Color.Red);
					break;
				case 3:
					br = new SolidBrush(Color.Green);
					break;
				case 4:
					br = new SolidBrush(Color.Yellow);
					break;
				case 5:
					br = new SolidBrush(Color.DarkOrange);
					break;
				case 6:
					br = new SolidBrush(Color.Pink);
					break;				
				case 7:
					br = new SolidBrush(Color.Black);
					break;	
				case 8:
					br = new SolidBrush(Color.White);
					break;	
				case 9:
					br = new SolidBrush(Color.Gray);
					break;	
				default:
					break;
			}
			return br;
		}//GetBrush

		public SolidBrush[,] getTabuleiro()
		{
			return tab;
		}//getTabuleiro
	}

}
