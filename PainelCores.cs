using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mastermind
{
	/// <summary>
	/// Summary description for PainelCores.
	/// </summary>
	public class PainelCores
	{
		private Point posicao;
		private int altura = 20;
		private int largura = 6 * 40;
		private Rectangle moldura;

		public PainelCores(int x, int y)
		{			
			posicao = new Point(x,y);
			moldura = new Rectangle(x,y,largura,altura);
		}//construtor

		public void Draw(Graphics g)
		{
			Pen p = new Pen(Color.Black);
			g.DrawRectangle(p, posicao.X, posicao.Y-1, largura, altura+1);
			for (int i = 0; i< 6; i++)
			{
				g.FillRectangle(Tabuleiro.GetBrush(i+1), posicao.X+(i*40), posicao.Y,40,altura);
			}
		}//Draw

		public int GetColorAt(int x, int y)
		{
			int resultado = -1;
			if (moldura.Contains(x,y) == false)
				return resultado;		  
			return  (x - posicao.X)/40 + 1;		
		}//GetColorAt
	}
}