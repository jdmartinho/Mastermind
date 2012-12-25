using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mastermind
{
	/// <summary>
	/// Summary description for TabuleiroScore.
	/// </summary>
	public class TabuleiroScore
	{

		private SolidBrush[,] tab;
		private Rectangle bola;
		private int inicialX;
		private int inicialY;
		private const int ALTURA = 10;
		private const int LARGURA = 10;
		private int posicaoX;
		private int posicaoY;

		public TabuleiroScore()
		{
			inicialX = 170;
			inicialY = 11;

			tab = new SolidBrush[12,4];
			for(int i = 0;i<12;i++)
			{
				for(int j = 0;j<4;j++)
				{
					tab[i,j] = new SolidBrush(Color.Gray);
				}
			}
			posicaoX = inicialX;
			posicaoY = inicialY;
		}//construtor

		public TabuleiroScore(int xInicial, int yInicial)
		{
			inicialX = xInicial;
			inicialY = yInicial;

			tab = new SolidBrush[12,4];
			for(int i = 0;i<12;i++)
			{
				for(int j = 0;j<4;j++)
				{
					tab[i,j] = new SolidBrush(Color.Gray);
				}
			}
			posicaoX = inicialX;
			posicaoY = inicialY;
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

		public void setTabScore(SolidBrush[,] sbs)
		{
			tab = sbs;
		}//setTabScore

		public void pintaBola(int bola, int jogada, SolidBrush br)
		{			
			switch(bola)
			{
				case 1: tab[jogada,0] = br;
					break;
				case 2: tab[jogada,1] = br;
					break;
				case 3: tab[jogada,2] = br;
					break;
				case 4: tab[jogada,3] = br;
					break;
				default: break;
			}
		}//pintaBola

		public void Draw(Graphics graphicsObject)
		{
			Pen p = new Pen(Color.Black);
			SolidBrush br;
			posicaoY = inicialY;

			for(int i = 0;i<12;i++)
			{
				for(int j = 0;j<4;j++)
				{					
					bola = new Rectangle(posicaoX,posicaoY,LARGURA,ALTURA);
					br = tab[i,j];
					graphicsObject.DrawEllipse(p,bola);
					if(!br.Color.Equals(Color.White))
					{
						graphicsObject.FillEllipse(br,bola);
					}
					posicaoX += 13;					
				}
				posicaoX = inicialX;
				posicaoY += 16;
			}
		}//Draw

		public SolidBrush[,] getTabScore()
		{
			return tab;
		}//getTabScore

		public SolidBrush[] getLinha(int linha)
		{
			SolidBrush[] result = new SolidBrush[4];
			for(int i = 0; i<4; i++)
			{
				result[i] = tab[linha,i];
			}				
			return result;
		}//getLinha
	}
}
