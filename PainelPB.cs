using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mastermind
{
	/// <summary>
	/// Summary description for PainelPB.
	/// </summary>
	public class PainelPB
	{
		private Point posicao;
		private int altura = 20;
		private int largura = 2 * 120;
		private Rectangle moldura;

		public PainelPB(int x, int y)
		{
			posicao = new Point(x,y);
			moldura = new Rectangle(x,y,largura,altura);
		}//construtor	

		public void Draw(Graphics g)
		{
			Pen p = new Pen(Color.Black);
			g.DrawRectangle(p, posicao.X, posicao.Y-1, largura, altura+1);
			int j = 0;
			for (int i = 6; i< 8; i++)
			{				
				g.FillRectangle(Tabuleiro.GetBrush(i+1), posicao.X+(j*120), posicao.Y,120,altura);
				j++;
			}
		}//Draw

		public int GetColorAt(int x, int y)
		{
			int resultado = -1;
			if (moldura.Contains(x,y) == false)
				return resultado;		  
			return  (x - posicao.X)/120 + 7;		
		}//GetColorAt
	}
}
