using System;
using System.Drawing;

namespace Mastermind
{
	/// <summary>
	/// Summary description for CodigoCores.
	/// </summary>
	public class CodigoCores
	{
		private Rectangle r1;
		private Rectangle r2;
		private Rectangle r3;
		private Rectangle r4;		
		private SolidBrush[] brs;

		public CodigoCores(int x, int y, Color cor)
		{
	        r1 = new Rectangle(x,y,20,20);			
			r2 = new Rectangle(x+25,y,20,20);
			r3 = new Rectangle(x+50,y,20,20);
			r4 = new Rectangle(x+75,y,20,20);				
			brs = new SolidBrush[4];
			for(int i=0;i<4;i++)
			{
				brs[i] = new SolidBrush(cor);
			}
		}//construtor

		public void Draw(Graphics grafico)
		{
			Pen p = new Pen(Color.Black);			

			grafico.DrawEllipse(p,r1);
			grafico.FillEllipse(brs[0],r1);
			grafico.DrawEllipse(p,r2);
			grafico.FillEllipse(brs[1],r2);
			grafico.DrawEllipse(p,r3);
			grafico.FillEllipse(brs[2],r3);
			grafico.DrawEllipse(p,r4);
			grafico.FillEllipse(brs[3],r4);
		}//Draw

		public void pintaBola(int bola, SolidBrush br)
		{			
			switch(bola)
			{
				case 1: brs[0] = br;
					break;
				case 2: brs[1] = br;
					break;
				case 3: brs[2] = br;
					break;
				case 4: brs[3] = br;
					break;
				default: break;
			}
		}//pintaBola

		public bool CodigoValido()
		{
			bool result = true;
			for(int i=0; i<4; i++) 
			{
				if (brs[i].Equals(Color.Black)) result = false;
				break;
			}
			return result;
		}//CodigoValido

		public SolidBrush[] getCodigo()
		{
			return brs;
		}//getCodigo

		public void setCodigo(SolidBrush[] sbrs)
		{
			brs = sbrs;
		}//setCodigo
	}
}

