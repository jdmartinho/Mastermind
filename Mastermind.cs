using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace Mastermind
{
	/// <summary>
	/// Summary description for Form1.///////////////
	/// </summary>
	public class Mastermind : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBoxFCUL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton radioButtonModo1;
		private System.Windows.Forms.RadioButton radioButtonModo2;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonIniciar;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panelInicial;
		private System.Windows.Forms.Panel panelConeccao;
		private System.Windows.Forms.Button buttonFazConeccao;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton radioButtonServer;
		private System.Windows.Forms.RadioButton radioButtonClient;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panelNumJogos;
		private System.Windows.Forms.Panel panelCifrador;
		private System.Windows.Forms.Panel panelDecifrador;
		private System.Windows.Forms.Panel panelEscolhaCor;
		private System.Windows.Forms.Panel panelResultados;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.Button botaoApagarEscolhaCor;
		private System.Windows.Forms.Button botaoOKEscolhaCor;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label labelAdversario;
		private System.Windows.Forms.Label labelJogador;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label labelPontuacaoJogador;
		private System.Windows.Forms.Label labelPontuacaoAdversario;
		private System.Windows.Forms.Button botaoTerminar;
		private System.Windows.Forms.Panel panelEndIp;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBoxEndIp;
		private System.Windows.Forms.Button buttonVoltarConIni;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button botaoDecifradorApagar;
		private System.Windows.Forms.Button botaoDecifradorOK;
		private System.Windows.Forms.Button botaoCifradorApagar;
		private System.Windows.Forms.Button botaoCifradorOK;
		private System.Windows.Forms.Panel panelCifradorTabScore;
		private System.Windows.Forms.Panel panelCifradorCodSecreto;
		private System.Windows.Forms.Panel panelEsperaDecifrador;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Panel panelResultadosClassico;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label labelJogadorClassico;
		private System.Windows.Forms.Label labelAdversarioClassico;
		private System.Windows.Forms.Label labelResultadosJogador;
		private System.Windows.Forms.Label labelResultadosAdversario;
		private System.Windows.Forms.Button buttonSairClassico;
		private System.Windows.Forms.Label labelTotalJogador;
		private System.Windows.Forms.Label labelTotalAdversario;
		private System.Windows.Forms.Button botaoAjuda;
		private System.Windows.Forms.Label labelAjuda;
		private System.Windows.Forms.Button botaoVoltarAjuda;
		private System.Windows.Forms.Panel panelAjuda;
		private System.Windows.Forms.Label label18;

		//Variáveis usadas 
		private int contadorBolas = 1;		
		private PainelCores painel;
		private PainelPB painelPB;
		private CodigoCores codigo;
		private Tabuleiro tabuleiro;
		private System.Windows.Forms.Panel panelDecifradorCodigoCor;
		private TabuleiroScore tabScore;
		private int nJogada = 0;
		private SolidBrush[] scoreJogada = new SolidBrush[4];		
		private int pontuacaoSimultanea = 0;		
		private Comunicacao com;
		private ComunicacaoClassica comClassica;
		private bool final = false;	
		private SolidBrush[] codigoSecreto = new SolidBrush[4];
		private int nJogos;
		private int[] pontuacoes;
		private bool correUmaVez = false;
		private int jogosJogados = 0;		
		private int nJogosInicial;
		private int acumuladorJogador = 0;
		private int acumuladorAdversario = 0;

		public Mastermind()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.panelCifrador.Paint += new PaintEventHandler(panelCifrador_Paint);
			this.panelCifrador.MouseDown += new MouseEventHandler(panelCifrador_MouseDown);
			this.panelDecifrador.Paint += new PaintEventHandler(panelDecifrador_Paint);
			this.panelDecifrador.MouseDown += new MouseEventHandler(panelDecifrador_MouseDown);		
			this.panelCifradorTabScore.Paint += new PaintEventHandler(panelCifradorTabScore_Paint);
			this.panelDecifradorCodigoCor.Paint += new PaintEventHandler(panelDecifradorCodigoCor_Paint);
			this.panelCifradorCodSecreto.Paint += new PaintEventHandler(panelCifradorCodSecreto_Paint);
			this.panelEscolhaCor.Paint += new PaintEventHandler(panelEscolhaCor_Paint);
			this.panelEscolhaCor.MouseDown += new MouseEventHandler(panelEscolhaCor_MouseDown);				
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Mastermind));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.panelInicial = new System.Windows.Forms.Panel();
			this.panelAjuda = new System.Windows.Forms.Panel();
			this.label18 = new System.Windows.Forms.Label();
			this.labelAjuda = new System.Windows.Forms.Label();
			this.botaoVoltarAjuda = new System.Windows.Forms.Button();
			this.botaoAjuda = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonIniciar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.radioButtonModo2 = new System.Windows.Forms.RadioButton();
			this.radioButtonModo1 = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBoxFCUL = new System.Windows.Forms.PictureBox();
			this.panelConeccao = new System.Windows.Forms.Panel();
			this.buttonVoltarConIni = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioButtonClient = new System.Windows.Forms.RadioButton();
			this.radioButtonServer = new System.Windows.Forms.RadioButton();
			this.buttonFazConeccao = new System.Windows.Forms.Button();
			this.panelEndIp = new System.Windows.Forms.Panel();
			this.textBoxEndIp = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.panelNumJogos = new System.Windows.Forms.Panel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panelCifrador = new System.Windows.Forms.Panel();
			this.panelCifradorCodSecreto = new System.Windows.Forms.Panel();
			this.panelCifradorTabScore = new System.Windows.Forms.Panel();
			this.botaoCifradorOK = new System.Windows.Forms.Button();
			this.botaoCifradorApagar = new System.Windows.Forms.Button();
			this.panelDecifrador = new System.Windows.Forms.Panel();
			this.panelEsperaDecifrador = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.panelDecifradorCodigoCor = new System.Windows.Forms.Panel();
			this.botaoDecifradorOK = new System.Windows.Forms.Button();
			this.botaoDecifradorApagar = new System.Windows.Forms.Button();
			this.panelEscolhaCor = new System.Windows.Forms.Panel();
			this.botaoOKEscolhaCor = new System.Windows.Forms.Button();
			this.botaoApagarEscolhaCor = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.panelResultados = new System.Windows.Forms.Panel();
			this.label13 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.botaoTerminar = new System.Windows.Forms.Button();
			this.labelPontuacaoAdversario = new System.Windows.Forms.Label();
			this.labelPontuacaoJogador = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.labelAdversario = new System.Windows.Forms.Label();
			this.labelJogador = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.panelResultadosClassico = new System.Windows.Forms.Panel();
			this.labelTotalAdversario = new System.Windows.Forms.Label();
			this.labelTotalJogador = new System.Windows.Forms.Label();
			this.buttonSairClassico = new System.Windows.Forms.Button();
			this.labelResultadosAdversario = new System.Windows.Forms.Label();
			this.labelResultadosJogador = new System.Windows.Forms.Label();
			this.labelAdversarioClassico = new System.Windows.Forms.Label();
			this.labelJogadorClassico = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			// 
			// panelInicial
			// 
			this.panelInicial.Controls.Add(this.panelAjuda);
			this.panelInicial.Controls.Add(this.botaoAjuda);
			this.panelInicial.Controls.Add(this.pictureBox1);
			this.panelInicial.Controls.Add(this.buttonIniciar);
			this.panelInicial.Controls.Add(this.label4);
			this.panelInicial.Controls.Add(this.textBoxUsername);
			this.panelInicial.Controls.Add(this.panel2);
			this.panelInicial.Controls.Add(this.label2);
			this.panelInicial.Controls.Add(this.label1);
			this.panelInicial.Controls.Add(this.pictureBoxFCUL);
			this.panelInicial.Size = new System.Drawing.Size(240, 272);
			// 
			// panelAjuda
			// 
			this.panelAjuda.Controls.Add(this.label18);
			this.panelAjuda.Controls.Add(this.labelAjuda);
			this.panelAjuda.Controls.Add(this.botaoVoltarAjuda);
			this.panelAjuda.Size = new System.Drawing.Size(240, 272);
			this.panelAjuda.Visible = false;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label18.Location = new System.Drawing.Point(-8, 0);
			this.label18.Size = new System.Drawing.Size(272, 16);
			this.label18.Text = "Regras do Jogo:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelAjuda
			// 
			this.labelAjuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
			this.labelAjuda.Location = new System.Drawing.Point(0, 16);
			this.labelAjuda.Size = new System.Drawing.Size(240, 224);
			this.labelAjuda.Text = @"O cifrador constrói o código composto por 4 peças de cor, e o decifrador, irá tentar em 12 tentativas adivinhar esse código. Em cada tentativa, o decifrador coloca 4 peças código numa fila do tabuleiro. Depois de colocadas, o cifrador responde, colocando, nos furos menores da mesma fila, para cada cor certa no lugar errado uma peça branca e para cada cor certa no lugar certo uma peça preta. Depois de avaliar a resposta fornecida pelo cifrador, o decifrador faz nova tentativa. As tentativas e as respostas sucedem-se alternadamente. O cifrador recebe 1 ponto por cada tentativa do decifrador. Um ponto extra é atribuído ao cifrador se o decifrador não acertar no código. O vencedor é aquele que conseguir mais pontos depois do número de jogos acordados.";
			// 
			// botaoVoltarAjuda
			// 
			this.botaoVoltarAjuda.Location = new System.Drawing.Point(80, 248);
			this.botaoVoltarAjuda.Size = new System.Drawing.Size(88, 16);
			this.botaoVoltarAjuda.Text = "Voltar";
			this.botaoVoltarAjuda.Click += new System.EventHandler(this.botaoVoltarAjuda_Click);
			// 
			// botaoAjuda
			// 
			this.botaoAjuda.Location = new System.Drawing.Point(8, 240);
			this.botaoAjuda.Size = new System.Drawing.Size(96, 20);
			this.botaoAjuda.Text = "Ajuda";
			this.botaoAjuda.Click += new System.EventHandler(this.botaoAjuda_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 128);
			this.pictureBox1.Size = new System.Drawing.Size(240, 24);
			// 
			// buttonIniciar
			// 
			this.buttonIniciar.Location = new System.Drawing.Point(120, 240);
			this.buttonIniciar.Size = new System.Drawing.Size(96, 20);
			this.buttonIniciar.Text = "Iniciar Jogo";
			this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 152);
			this.label4.Size = new System.Drawing.Size(104, 24);
			this.label4.Text = "Nome do Jogador:";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(120, 152);
			this.textBoxUsername.Size = new System.Drawing.Size(112, 20);
			this.textBoxUsername.Text = "";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.radioButtonModo2);
			this.panel2.Controls.Add(this.radioButtonModo1);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Location = new System.Drawing.Point(0, 184);
			this.panel2.Size = new System.Drawing.Size(240, 48);
			// 
			// radioButtonModo2
			// 
			this.radioButtonModo2.Location = new System.Drawing.Point(120, 24);
			this.radioButtonModo2.Text = "Simultâneo";
			// 
			// radioButtonModo1
			// 
			this.radioButtonModo1.Location = new System.Drawing.Point(120, 0);
			this.radioButtonModo1.Text = "Clássico";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Size = new System.Drawing.Size(104, 32);
			this.label3.Text = "Modo de Jogo:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 104);
			this.label2.Size = new System.Drawing.Size(120, 16);
			this.label2.Text = "Grupo cm019";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(64, 80);
			this.label1.Size = new System.Drawing.Size(120, 32);
			this.label1.Text = "MasterMind";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pictureBoxFCUL
			// 
			this.pictureBoxFCUL.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFCUL.Image")));
			this.pictureBoxFCUL.Size = new System.Drawing.Size(240, 72);
			this.pictureBoxFCUL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			// 
			// panelConeccao
			// 
			this.panelConeccao.Controls.Add(this.buttonVoltarConIni);
			this.panelConeccao.Controls.Add(this.label7);
			this.panelConeccao.Controls.Add(this.panel1);
			this.panelConeccao.Controls.Add(this.buttonFazConeccao);
			this.panelConeccao.Controls.Add(this.panelEndIp);
			this.panelConeccao.Controls.Add(this.panelNumJogos);
			this.panelConeccao.Size = new System.Drawing.Size(240, 272);
			this.panelConeccao.Visible = false;
			// 
			// buttonVoltarConIni
			// 
			this.buttonVoltarConIni.Location = new System.Drawing.Point(24, 168);
			this.buttonVoltarConIni.Size = new System.Drawing.Size(80, 20);
			this.buttonVoltarConIni.Text = "Voltar";
			this.buttonVoltarConIni.Click += new System.EventHandler(this.buttonVoltarConIni_Click);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular);
			this.label7.Location = new System.Drawing.Point(56, 16);
			this.label7.Size = new System.Drawing.Size(136, 16);
			this.label7.Text = "Ligações";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.radioButtonClient);
			this.panel1.Controls.Add(this.radioButtonServer);
			this.panel1.Location = new System.Drawing.Point(0, 40);
			this.panel1.Size = new System.Drawing.Size(240, 56);
			// 
			// radioButtonClient
			// 
			this.radioButtonClient.Location = new System.Drawing.Point(80, 32);
			this.radioButtonClient.Size = new System.Drawing.Size(152, 20);
			this.radioButtonClient.Text = "Juntar-se a jogo";
			this.radioButtonClient.CheckedChanged += new System.EventHandler(this.radioButtonClient_CheckedChanged);
			// 
			// radioButtonServer
			// 
			this.radioButtonServer.Location = new System.Drawing.Point(80, 8);
			this.radioButtonServer.Size = new System.Drawing.Size(136, 20);
			this.radioButtonServer.Text = "Criar jogo";
			this.radioButtonServer.CheckedChanged += new System.EventHandler(this.radioButtonServer_CheckedChanged);
			// 
			// buttonFazConeccao
			// 
			this.buttonFazConeccao.Location = new System.Drawing.Point(128, 168);
			this.buttonFazConeccao.Size = new System.Drawing.Size(80, 20);
			this.buttonFazConeccao.Text = "Iniciar";
			this.buttonFazConeccao.Click += new System.EventHandler(this.buttonFazConeccao_Click);
			// 
			// panelEndIp
			// 
			this.panelEndIp.Controls.Add(this.textBoxEndIp);
			this.panelEndIp.Controls.Add(this.label12);
			this.panelEndIp.Location = new System.Drawing.Point(0, 96);
			this.panelEndIp.Size = new System.Drawing.Size(240, 64);
			this.panelEndIp.Visible = false;
			// 
			// textBoxEndIp
			// 
			this.textBoxEndIp.Location = new System.Drawing.Point(128, 24);
			this.textBoxEndIp.Size = new System.Drawing.Size(80, 20);
			this.textBoxEndIp.Text = "172.20.6.23";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(24, 16);
			this.label12.Size = new System.Drawing.Size(96, 48);
			this.label12.Text = "Introduza o endereço ip do adversário:";
			// 
			// panelNumJogos
			// 
			this.panelNumJogos.Controls.Add(this.comboBox1);
			this.panelNumJogos.Controls.Add(this.label6);
			this.panelNumJogos.Location = new System.Drawing.Point(0, 96);
			this.panelNumJogos.Size = new System.Drawing.Size(240, 64);
			this.panelNumJogos.Visible = false;
			// 
			// comboBox1
			// 
			this.comboBox1.Items.Add("2");
			this.comboBox1.Items.Add("4");
			this.comboBox1.Items.Add("6");
			this.comboBox1.Items.Add("8");
			this.comboBox1.Items.Add("10");
			this.comboBox1.Items.Add("12");
			this.comboBox1.Items.Add("14");
			this.comboBox1.Items.Add("16");
			this.comboBox1.Location = new System.Drawing.Point(144, 24);
			this.comboBox1.Size = new System.Drawing.Size(56, 21);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(32, 16);
			this.label6.Size = new System.Drawing.Size(96, 40);
			this.label6.Text = "Número de jogos por partida:";
			// 
			// panelCifrador
			// 
			this.panelCifrador.Controls.Add(this.panelCifradorCodSecreto);
			this.panelCifrador.Controls.Add(this.panelCifradorTabScore);
			this.panelCifrador.Controls.Add(this.botaoCifradorOK);
			this.panelCifrador.Controls.Add(this.botaoCifradorApagar);
			this.panelCifrador.Size = new System.Drawing.Size(240, 272);
			this.panelCifrador.Visible = false;
			// 
			// panelCifradorCodSecreto
			// 
			this.panelCifradorCodSecreto.Location = new System.Drawing.Point(0, 211);
			this.panelCifradorCodSecreto.Size = new System.Drawing.Size(160, 39);
			// 
			// panelCifradorTabScore
			// 
			this.panelCifradorTabScore.Location = new System.Drawing.Point(170, 11);
			this.panelCifradorTabScore.Size = new System.Drawing.Size(70, 200);
			// 
			// botaoCifradorOK
			// 
			this.botaoCifradorOK.Location = new System.Drawing.Point(160, 231);
			this.botaoCifradorOK.Size = new System.Drawing.Size(72, 16);
			this.botaoCifradorOK.Text = "OK";
			this.botaoCifradorOK.Click += new System.EventHandler(this.botaoCifradorOK_Click);
			// 
			// botaoCifradorApagar
			// 
			this.botaoCifradorApagar.Location = new System.Drawing.Point(160, 211);
			this.botaoCifradorApagar.Size = new System.Drawing.Size(72, 16);
			this.botaoCifradorApagar.Text = "Apagar";
			this.botaoCifradorApagar.Click += new System.EventHandler(this.botaoCifradorApagar_Click);
			// 
			// panelDecifrador
			// 
			this.panelDecifrador.Controls.Add(this.panelEsperaDecifrador);
			this.panelDecifrador.Controls.Add(this.panelDecifradorCodigoCor);
			this.panelDecifrador.Controls.Add(this.botaoDecifradorOK);
			this.panelDecifrador.Controls.Add(this.botaoDecifradorApagar);
			this.panelDecifrador.Size = new System.Drawing.Size(240, 272);
			this.panelDecifrador.Visible = false;
			// 
			// panelEsperaDecifrador
			// 
			this.panelEsperaDecifrador.Controls.Add(this.label14);
			this.panelEsperaDecifrador.Location = new System.Drawing.Point(64, 88);
			this.panelEsperaDecifrador.Size = new System.Drawing.Size(104, 48);
			this.panelEsperaDecifrador.Visible = false;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 16);
			this.label14.Size = new System.Drawing.Size(72, 16);
			this.label14.Text = "Em espera...";
			// 
			// panelDecifradorCodigoCor
			// 
			this.panelDecifradorCodigoCor.Location = new System.Drawing.Point(0, 211);
			this.panelDecifradorCodigoCor.Size = new System.Drawing.Size(160, 40);
			// 
			// botaoDecifradorOK
			// 
			this.botaoDecifradorOK.Location = new System.Drawing.Point(160, 231);
			this.botaoDecifradorOK.Size = new System.Drawing.Size(72, 16);
			this.botaoDecifradorOK.Text = "OK";
			this.botaoDecifradorOK.Click += new System.EventHandler(this.botaoDecifradorOK_Click);
			// 
			// botaoDecifradorApagar
			// 
			this.botaoDecifradorApagar.Location = new System.Drawing.Point(160, 211);
			this.botaoDecifradorApagar.Size = new System.Drawing.Size(72, 16);
			this.botaoDecifradorApagar.Text = "Apagar";
			this.botaoDecifradorApagar.Click += new System.EventHandler(this.botaoDecifradorApagar_Click);
			// 
			// panelEscolhaCor
			// 
			this.panelEscolhaCor.Controls.Add(this.botaoOKEscolhaCor);
			this.panelEscolhaCor.Controls.Add(this.botaoApagarEscolhaCor);
			this.panelEscolhaCor.Controls.Add(this.label8);
			this.panelEscolhaCor.Size = new System.Drawing.Size(240, 272);
			this.panelEscolhaCor.Visible = false;
			// 
			// botaoOKEscolhaCor
			// 
			this.botaoOKEscolhaCor.Location = new System.Drawing.Point(136, 200);
			this.botaoOKEscolhaCor.Text = "OK";
			this.botaoOKEscolhaCor.Click += new System.EventHandler(this.botaoOKEscolhaCor_Click);
			// 
			// botaoApagarEscolhaCor
			// 
			this.botaoApagarEscolhaCor.Location = new System.Drawing.Point(32, 200);
			this.botaoApagarEscolhaCor.Text = "Apagar";
			this.botaoApagarEscolhaCor.Click += new System.EventHandler(this.botaoApagarEscolhaCor_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 16);
			this.label8.Size = new System.Drawing.Size(240, 24);
			this.label8.Text = "Escolha o seu código secreto de cores:";
			// 
			// panelResultados
			// 
			this.panelResultados.Controls.Add(this.label13);
			this.panelResultados.Controls.Add(this.label5);
			this.panelResultados.Controls.Add(this.botaoTerminar);
			this.panelResultados.Controls.Add(this.labelPontuacaoAdversario);
			this.panelResultados.Controls.Add(this.labelPontuacaoJogador);
			this.panelResultados.Controls.Add(this.label11);
			this.panelResultados.Controls.Add(this.label10);
			this.panelResultados.Controls.Add(this.labelAdversario);
			this.panelResultados.Controls.Add(this.labelJogador);
			this.panelResultados.Controls.Add(this.label9);
			this.panelResultados.Size = new System.Drawing.Size(240, 272);
			this.panelResultados.Visible = false;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(120, 112);
			this.label13.Size = new System.Drawing.Size(64, 20);
			this.label13.Text = "Pontuação:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 112);
			this.label5.Size = new System.Drawing.Size(64, 20);
			this.label5.Text = "Pontuação:";
			// 
			// botaoTerminar
			// 
			this.botaoTerminar.Location = new System.Drawing.Point(80, 200);
			this.botaoTerminar.Text = "Sair";
			this.botaoTerminar.Click += new System.EventHandler(this.botaoTerminar_Click);
			// 
			// labelPontuacaoAdversario
			// 
			this.labelPontuacaoAdversario.Location = new System.Drawing.Point(192, 112);
			this.labelPontuacaoAdversario.Size = new System.Drawing.Size(24, 20);
			this.labelPontuacaoAdversario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelPontuacaoJogador
			// 
			this.labelPontuacaoJogador.Location = new System.Drawing.Point(88, 112);
			this.labelPontuacaoJogador.Size = new System.Drawing.Size(24, 20);
			this.labelPontuacaoJogador.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(120, 48);
			this.label11.Size = new System.Drawing.Size(96, 20);
			this.label11.Text = "Adversário:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 48);
			this.label10.Size = new System.Drawing.Size(96, 20);
			this.label10.Text = "Jogador:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelAdversario
			// 
			this.labelAdversario.Location = new System.Drawing.Point(120, 80);
			this.labelAdversario.Size = new System.Drawing.Size(96, 20);
			this.labelAdversario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelJogador
			// 
			this.labelJogador.Location = new System.Drawing.Point(16, 80);
			this.labelJogador.Size = new System.Drawing.Size(96, 20);
			this.labelJogador.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(88, 8);
			this.label9.Size = new System.Drawing.Size(64, 20);
			this.label9.Text = "Resultados";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panelResultadosClassico
			// 
			this.panelResultadosClassico.Controls.Add(this.labelTotalAdversario);
			this.panelResultadosClassico.Controls.Add(this.labelTotalJogador);
			this.panelResultadosClassico.Controls.Add(this.buttonSairClassico);
			this.panelResultadosClassico.Controls.Add(this.labelResultadosAdversario);
			this.panelResultadosClassico.Controls.Add(this.labelResultadosJogador);
			this.panelResultadosClassico.Controls.Add(this.labelAdversarioClassico);
			this.panelResultadosClassico.Controls.Add(this.labelJogadorClassico);
			this.panelResultadosClassico.Controls.Add(this.label17);
			this.panelResultadosClassico.Controls.Add(this.label16);
			this.panelResultadosClassico.Controls.Add(this.label15);
			this.panelResultadosClassico.Size = new System.Drawing.Size(240, 272);
			this.panelResultadosClassico.Visible = false;
			// 
			// labelTotalAdversario
			// 
			this.labelTotalAdversario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.labelTotalAdversario.Location = new System.Drawing.Point(128, 192);
			this.labelTotalAdversario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelTotalJogador
			// 
			this.labelTotalJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.labelTotalJogador.Location = new System.Drawing.Point(8, 192);
			this.labelTotalJogador.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// buttonSairClassico
			// 
			this.buttonSairClassico.Location = new System.Drawing.Point(80, 232);
			this.buttonSairClassico.Text = "Sair";
			this.buttonSairClassico.Click += new System.EventHandler(this.buttonSairClassico_Click);
			// 
			// labelResultadosAdversario
			// 
			this.labelResultadosAdversario.Location = new System.Drawing.Point(128, 80);
			this.labelResultadosAdversario.Size = new System.Drawing.Size(112, 104);
			// 
			// labelResultadosJogador
			// 
			this.labelResultadosJogador.Location = new System.Drawing.Point(8, 80);
			this.labelResultadosJogador.Size = new System.Drawing.Size(120, 104);
			// 
			// labelAdversarioClassico
			// 
			this.labelAdversarioClassico.Location = new System.Drawing.Point(128, 56);
			this.labelAdversarioClassico.Size = new System.Drawing.Size(100, 16);
			this.labelAdversarioClassico.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelJogadorClassico
			// 
			this.labelJogadorClassico.Location = new System.Drawing.Point(8, 56);
			this.labelJogadorClassico.Size = new System.Drawing.Size(100, 16);
			this.labelJogadorClassico.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline);
			this.label17.Location = new System.Drawing.Point(128, 32);
			this.label17.Size = new System.Drawing.Size(100, 16);
			this.label17.Text = "Adversário";
			this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline);
			this.label16.Location = new System.Drawing.Point(8, 32);
			this.label16.Size = new System.Drawing.Size(104, 16);
			this.label16.Text = "Jogador";
			this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label15.Location = new System.Drawing.Point(64, 8);
			this.label15.Text = "Resultados";
			this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Mastermind
			// 
			this.Controls.Add(this.panelInicial);
			this.Controls.Add(this.panelDecifrador);
			this.Controls.Add(this.panelCifrador);
			this.Controls.Add(this.panelResultadosClassico);
			this.Controls.Add(this.panelResultados);
			this.Controls.Add(this.panelEscolhaCor);
			this.Controls.Add(this.panelConeccao);
			this.Menu = this.mainMenu1;
			this.Text = "Mastermind";
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new Mastermind());
		}//Main

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}//Form1_Load

		//Método que reinicia o jogo quando um dos jogadores acaba
		private void reiniciaJogo()
		{
			if(nJogos==0) 
			{				
				if(this.radioButtonServer.Checked)
				{			
					acumuladorJogador = 0;
					acumuladorAdversario = 0;
					for(int i = 0; i<nJogosInicial;i++)
					{
						if( i % 2 == 0)
						{
							int j = i + 1;
							this.labelResultadosAdversario.Text += "Jogo " + j.ToString() + ":    " + pontuacoes[i].ToString() + " pontos\n";
							acumuladorAdversario += pontuacoes[i];
						}
						else
						{
							int j = i + 1;
							this.labelResultadosJogador.Text += "Jogo " + j.ToString() + ":    " + pontuacoes[i].ToString()+ " pontos\n";
							acumuladorJogador += pontuacoes[i];
						}                        
					}					
					this.labelJogadorClassico.Text = this.textBoxUsername.Text;
					this.labelAdversarioClassico.Text = comClassica.getUsername();
					this.labelTotalJogador.Text = "Total: " + acumuladorJogador.ToString();
					this.labelTotalAdversario.Text = "Total: " + acumuladorAdversario.ToString();
					this.panelCifrador.Visible = false;
					this.panelResultadosClassico.Visible = true;
				}
				else
				{					
					acumuladorJogador = 0;
					acumuladorAdversario = 0;
					for(int i = 0; i<nJogosInicial;i++)
					{
						if( i % 2 == 0)
						{
							int j = i + 1;
							this.labelResultadosJogador.Text += "Jogo " + j.ToString() + ":    " + pontuacoes[i].ToString()+ " pontos\n";
							acumuladorJogador += pontuacoes[i];
						}
						else
						{
							int j = i + 1;
							this.labelResultadosAdversario.Text += "Jogo " + j.ToString() + ":    " + pontuacoes[i].ToString()+ " pontos\n";
							acumuladorAdversario += pontuacoes[i];
						}                        
					}					
					this.labelJogadorClassico.Text = this.textBoxUsername.Text;
					this.labelAdversarioClassico.Text = comClassica.getUsername();		
					this.labelTotalJogador.Text = "Total: " + acumuladorJogador.ToString();
					this.labelTotalAdversario.Text = "Total: " + acumuladorAdversario.ToString();
					this.panelDecifrador.Visible = false;
					this.panelResultadosClassico.Visible = true;
				}				
			}
			else
			{
				nJogos--;
				jogosJogados++;
				correUmaVez = false;
				comClassica.reiniciar();
				contadorBolas = 1;
				nJogada = 0;			
				codigoSecreto = new SolidBrush[4];
				tabuleiro = new Tabuleiro();
				tabScore = new TabuleiroScore();		
				if(this.radioButtonServer.Checked) 
				{			
					this.radioButtonClient.Checked = true;
					painel = new PainelCores(0,252);
					codigo = new CodigoCores(30,9,Color.Black);
					this.radioButtonServer.Checked = false;
					this.panelConeccao.Visible = false;
					this.panelCifrador.Visible = false;						
					this.panelDecifrador.Visible = true;									
				}
				else
				{
					this.radioButtonServer.Checked = true;
					codigo = new CodigoCores(70,56,Color.Black);
					painel = new PainelCores(0,140);
					this.radioButtonClient.Checked = false;
					this.panelConeccao.Visible = false;
					this.panelDecifrador.Visible = false;				
					this.panelEscolhaCor.Visible = true;				
				}
			}
		}//reiniciaJogo

		/*******************
		 * Painel Inicial
		 *******************/

		private void buttonIniciar_Click(object sender, System.EventArgs e)
		{
			if((this.radioButtonModo1.Checked || this.radioButtonModo2.Checked) && !this.textBoxUsername.Text.Equals(""))
			{
				this.panelInicial.Visible = false;
				this.panelConeccao.Visible = true;
			}
			else MessageBox.Show("Dados incompletos");
		}//buttonIniciar_Click

		/*******************
		 * Painel Coneccao
		 *******************/

		private void radioButtonServer_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.radioButtonServer.Checked && this.radioButtonModo1.Checked) 
			{
				this.panelNumJogos.Visible = true;
				this.panelEndIp.Visible = false;
			}
			else 
			{
				this.panelNumJogos.Visible = false;
				this.panelEndIp.Visible = false;
			}
		}//radioButtonServer_CheckedChanged

		private void radioButtonClient_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.radioButtonClient.Checked) 
			{
				this.panelEndIp.Visible = true;
				this.panelNumJogos.Visible = false;
			}
		}//radioButtonCliente_CheckedChanged

		private void buttonVoltarConIni_Click(object sender, System.EventArgs e)
		{
			this.panelConeccao.Visible = false;
			this.panelInicial.Visible = true;
			this.panelEndIp.Visible = false;
			this.panelNumJogos.Visible = false;
			this.radioButtonClient.Checked = false;
			this.radioButtonServer.Checked = false;
		}//buttonVoltarConIni_Click

		private void buttonFazConeccao_Click(object sender, System.EventArgs e)
		{
			//Modo de jogo clássico
			if(this.radioButtonModo1.Checked)
			{
				tabuleiro = new Tabuleiro();
				tabScore = new TabuleiroScore();

				if(this.radioButtonServer.Checked)
				{
					if(this.comboBox1.SelectedIndex != -1)
					{
						codigo = new CodigoCores(70,56,Color.Black);
						painel = new PainelCores(0,140);
						this.panelConeccao.Visible = false;
						this.panelEscolhaCor.Visible = true;	
						nJogos = Convert.ToInt32(this.comboBox1.SelectedItem.ToString())-1;
						nJogosInicial = nJogos + 1;
						pontuacoes = new int[16];					
						comClassica = new ComunicacaoClassica();
						comClassica.servidorClassico();
						comClassica.enviarNJogos(nJogos);						
					}
					else MessageBox.Show("Escolha o número de jogos");
					
				}
				else if(this.radioButtonClient.Checked)
				{
					painel = new PainelCores(0,252);
					codigo = new CodigoCores(30,9,Color.Black);					
					pontuacoes = new int[16];
					this.panelConeccao.Visible = false;
					this.panelDecifrador.Visible = true;
					this.panelDecifradorCodigoCor.Visible = true;
					comClassica = new ComunicacaoClassica();
					comClassica.clienteClassico(this.textBoxEndIp.Text,8758);
					while(!comClassica.getJogosRecebidos()){}
					nJogos = comClassica.getNJogos();
					nJogosInicial = nJogos + 1;
				}
				else 
				{
					MessageBox.Show("Campos por preencher");
				}

			}
			//Modo de jogo simultâneo
			else if(this.radioButtonModo2.Checked)
			{
				this.panelConeccao.Visible = false;
				this.panelEscolhaCor.Visible = true;	
				painel = new PainelCores(0,140);
				codigo = new CodigoCores(70,56,Color.Black);

				if(this.radioButtonServer.Checked)
				{	
					com = new Comunicacao();
					com.servidorSimultaneo();									
				}
				else if(this.radioButtonClient.Checked)
				{	
					com = new Comunicacao();
					com.clienteSimultaneo(this.textBoxEndIp.Text,8758);					
				}
				else {
				
					MessageBox.Show("Campos por preencher");
				}

			}
			else MessageBox.Show("Preencha os campos necessários");
		}//buttonFazConeccao_Click

		/*******************
		 * Painel EscolhaCor
		 *******************/

		private void panelEscolhaCor_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;	
			painel.Draw(g);
			codigo.Draw(g);			
		}//panelEscolhaCor_Paint

		private void panelEscolhaCor_MouseDown(object sender, MouseEventArgs e) 
		{
			int bola = painel.GetColorAt(e.X,e.Y);
			if(bola != -1) 
			{
				SolidBrush br = Tabuleiro.GetBrush(bola);			
				codigo.pintaBola(contadorBolas++,br);
				this.panelEscolhaCor.Invalidate();
			}
		}//panelEscolhaCor_MouseDown

		private void botaoApagarEscolhaCor_Click(object sender, System.EventArgs e)
		{
			contadorBolas = 1;			
			codigo = new CodigoCores(70,56,Color.Black);
			this.panelEscolhaCor.Invalidate();		
		}//botaoApagarEscolhaCor_Click

		private void botaoOKEscolhaCor_Click(object sender, System.EventArgs e)
		{
			//Modo de jogo clássico
			if(this.radioButtonModo1.Checked)
			{
				Algoritmos alg = new Algoritmos();
				if(alg.ehValido(codigo.getCodigo()))
				{	                    
					painelPB = new PainelPB(0,252);
					SolidBrush[] sbrs = codigo.getCodigo();
					codigo = new CodigoCores(30,9,Color.Black);	
					codigo.setCodigo(sbrs);
					tabuleiro = new Tabuleiro();
					tabScore = new TabuleiroScore(0,0);
					this.panelCifradorCodSecreto.Visible = true;
					this.panelEscolhaCor.Visible = false;
					this.panelCifrador.Visible = true;
					this.panelCifradorTabScore.Visible = true;
					this.panelCifrador.Invalidate();
					contadorBolas = 1;
					comClassica.enviarUsername(this.textBoxUsername.Text);					
				}
				else 
				{
					MessageBox.Show("Código inválido!");
					contadorBolas = 1;			
					codigo = new CodigoCores(70,56,Color.Black);
					this.panelEscolhaCor.Invalidate();
				}
				contadorBolas = 1;		
			}
			//Modo de jogo simultâneo
			if(this.radioButtonModo2.Checked)
			{
				Algoritmos alg = new Algoritmos();
				if(alg.ehValido(codigo.getCodigo()))
				{					
					com.enviarUsername(this.textBoxUsername.Text);
					com.enviarCodigo(codigo.getCodigo());
					while(true)
					{
						if(com.getCodRecebido())
						{
							painel = new PainelCores(0,252);
							codigo = new CodigoCores(30,9,Color.Black);
							tabuleiro = new Tabuleiro();
							tabScore = new TabuleiroScore();
							this.panelEscolhaCor.Visible = false;
							this.panelDecifrador.Visible = true;
							break;
						}
					}
				}
				else MessageBox.Show("Código inválido!");
				contadorBolas = 1;			
				codigo = new CodigoCores(30,9,Color.Black);
				this.panelEscolhaCor.Invalidate();			
			}		
		}//botaoOKEscolhaCor_Click

		/*******************
		 * Painel Decifrador
		 *******************/

		private void panelDecifrador_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			tabuleiro.Draw(g);
			tabScore.Draw(g);
			painel.Draw(g);
			
			//Modo de jogo simultâneo
			if(this.radioButtonModo2.Checked)
			{
				Algoritmos alg = new Algoritmos();
				if(nJogada>0 && alg.ehFinal(scoreJogada) && !final)
				{				
					com.enviarPontuacao(pontuacaoSimultanea);				
					while(!final)
					{
						if(com.getTerminou())
						{							
							this.panelDecifrador.Visible = false;
							this.panelResultados.Visible = true;
							this.labelJogador.Text = this.textBoxUsername.Text;
							this.labelAdversario.Text = com.getUsername();
							this.labelPontuacaoJogador.Text = com.getPontuacao().ToString();
							this.labelPontuacaoAdversario.Text = pontuacaoSimultanea.ToString();						
							final = true;
							com.enviarTerminar(-1);												
							while(true)
							{
								if(com.getSocket().Connected && com.getFechou())
								{									
									com.getSocket().Shutdown(SocketShutdown.Both);						
									com.fechaLigacao();
									break;
								}							
							}
							break;
						}
					}
				}
				else if(nJogada==12 && !final)
				{				
					MessageBox.Show("Não dispõe de mais tentativas!");
					pontuacaoSimultanea = 13;
					com.enviarPontuacao(pontuacaoSimultanea);
					while(!final)
					{
						if(com.getTerminou())
						{
							this.panelDecifrador.Visible = false;
							this.panelResultados.Visible = true;
							this.labelJogador.Text = this.textBoxUsername.Text;
							this.labelAdversario.Text = com.getUsername();
							this.labelPontuacaoJogador.Text = com.getPontuacao().ToString();
							this.labelPontuacaoAdversario.Text = pontuacaoSimultanea.ToString();						
							final = true;
							com.enviarTerminar(-1);						
							while(true)
							{
								if(com.getSocket().Connected && com.getFechou())
								{									
									com.getSocket().Shutdown(SocketShutdown.Both);						
									com.fechaLigacao();
									break;
								}							
							}
							break;
						}
					}						
				}
			}
			//Modo de jogo clássico
			else if(this.radioButtonModo1.Checked)
			{
				Algoritmos alg = new Algoritmos();
				contadorBolas = -1;
				while(true)
				{
					if(comClassica.userRecebido())
					{
						contadorBolas = 1;						
						break;
					}
				}
				if(nJogada>0 && alg.ehFinal(tabScore.getLinha(nJogada-1)))
				{						
					pontuacoes[jogosJogados]=nJogada;								
					reiniciaJogo();						
				}
				if(nJogada == 12)
				{
					pontuacoes[jogosJogados]=nJogada+1;
					reiniciaJogo();					
				}						 
			}
		}//panelDecifrador_Paint

		private void panelDecifrador_MouseDown(object sender, MouseEventArgs e) 
		{	
			if(contadorBolas != -1) 
			{
				int bola = painel.GetColorAt(e.X,e.Y);
				if(bola != -1) 
				{
					SolidBrush br = Tabuleiro.GetBrush(bola);			
					codigo.pintaBola(contadorBolas++,br);
					this.panelDecifradorCodigoCor.Invalidate();
				}
			}
		}//panelDecifrador_MouseDown

		private void botaoDecifradorApagar_Click(object sender, System.EventArgs e)
		{
			contadorBolas = 1;			
			codigo = new CodigoCores(30,9,Color.Black);			
			this.panelDecifradorCodigoCor.Invalidate();		
		}//panelDecifradorApagar_Click		
		
		private void botaoDecifradorOK_Click(object sender, System.EventArgs e)
		{
			//Modo de jogo simultâneo
			if(this.radioButtonModo2.Checked)
			{
				SolidBrush[] jogada = codigo.getCodigo();
				Algoritmos alg = new Algoritmos();
				if(alg.ehValido(jogada))
				{		
					codigoSecreto = com.getCodigo();				
					scoreJogada = alg.comparaCodigo(codigoSecreto,jogada);
					tabuleiro.pintaLinha(nJogada,jogada);
					tabScore.pintaLinha(nJogada,scoreJogada);
					nJogada++;
					pontuacaoSimultanea++;
					this.panelDecifrador.Invalidate();
				}
				else MessageBox.Show("Código inválido!Tente outra vez!");
				contadorBolas = 1;			
				codigo = new CodigoCores(30,9,Color.Black);		
				this.panelDecifradorCodigoCor.Invalidate();	
			}
			//Modo de jogo clássico
			else if(this.radioButtonModo1.Checked)
			{
				SolidBrush[] jogada = codigo.getCodigo();
				Algoritmos alg = new Algoritmos();
				if(alg.ehValido(jogada))
				{		
					tabuleiro.pintaLinha(nJogada,jogada);
					nJogada++;					
					this.panelDecifrador.Invalidate();					
					comClassica.enviarTabCodigo(tabuleiro.getTabuleiro());
					while(!comClassica.getCodRecebido()) {}			
					tabScore.setTabScore(comClassica.getTabScore());
					this.panelDecifrador.Invalidate();					
				}
				else MessageBox.Show("Código inválido!Tente outra vez!");
				contadorBolas = 1;			
				codigo = new CodigoCores(30,9,Color.Black);		
				this.panelDecifradorCodigoCor.Invalidate();	
				comClassica.falsoRecebido();	
			}
		}//botaoDecifradorOK_Click

		/*******************
		 * Painel DecifradorCodigoCor
		 *******************/

		private void panelDecifradorCodigoCor_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			codigo.Draw(g);
		}//panelDecifradorCodigoCor_Paint


		/*******************
		 * Painel Cifrador
		 *******************/

		private void panelCifrador_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{			
			Graphics g = e.Graphics;
			tabuleiro.Draw(g);
			painelPB.Draw(g);
			
			if(!correUmaVez)
			{
				actualizaCifrador(g);
				correUmaVez = true;
			}			
		}//panelCifrador_Paint

		//Espera pela primeira jogada do decifrador
		private void actualizaCifrador(Graphics g)
		{
			while(!comClassica.getCodRecebido()) {}			
			comClassica.falsoRecebido();
			tabuleiro.setTabuleiro(comClassica.getTabuleiro());		
			tabuleiro.Draw(g);
		}//actualizaCifrador

		private void panelCifrador_MouseDown(object sender, MouseEventArgs e) 
		{			
			int bola = painelPB.GetColorAt(e.X,e.Y);
			if(bola != -1) 
			{				
				SolidBrush br = Tabuleiro.GetBrush(bola);			
				tabScore.pintaBola(contadorBolas++,nJogada,br);
				this.panelCifradorTabScore.Invalidate();
			}
		}//panelCifrador_MouseDown

		private void botaoCifradorApagar_Click(object sender, System.EventArgs e)
		{
			contadorBolas = 1;
			SolidBrush[,] sb = tabScore.getTabScore();
			for(int i = 0;i<4; i++)
			{
				sb[nJogada,i] = new SolidBrush(Color.Gray);
			}
			tabScore.setTabScore(sb);
			this.panelCifradorTabScore.Invalidate();			
		}//botaoCifradorApagar_Click
		
		private void botaoCifradorOK_Click(object sender, System.EventArgs e)
		{		
			Algoritmos alg = new Algoritmos();
			contadorBolas = 1;	
			SolidBrush[,] score = tabScore.getTabScore();				
			nJogada++;
			comClassica.enviarTabScore(score);	

			if(alg.ehFinal(tabScore.getLinha(nJogada-1)))
			{				
				pontuacoes[jogosJogados] = nJogada;
				reiniciaJogo();
			}
			else if(nJogada == 12)			
			{
				pontuacoes[jogosJogados] = nJogada + 1;
				reiniciaJogo();
			}
			else
			{
				while(!comClassica.getCodRecebido()){}
				tabuleiro.setTabuleiro(comClassica.getTabuleiro());		
				this.panelCifradorTabScore.Invalidate();
				this.panelCifrador.Invalidate();			
				comClassica.falsoRecebido();
			}
		}//botaoCifradorOK_Click

		/**************************
		 * Painel CifradorTabScore
		 **************************/

		private void panelCifradorTabScore_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;			
			tabScore.Draw(g);			
		}//panelCifradorTabScore_Paint

		/**************************
		 * Painel CifradorCodSecreto
		 **************************/

		private void panelCifradorCodSecreto_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;			
			codigo.Draw(g);			
		}//panelCifradorCodSecreto_Paint

		/*******************
		 * Painel Resultados
		 *******************/

		private void botaoTerminar_Click(object sender, System.EventArgs e)
		{	
			this.radioButtonClient.Checked = false;
			this.radioButtonServer.Checked = false;
			this.radioButtonModo1.Checked = false;
			this.radioButtonModo2.Checked = false;
			this.panelEndIp.Visible = false;
			this.panelResultados.Visible = false;
			this.panelInicial.Visible = true;							
			final = false;
			nJogada = 0;
			pontuacaoSimultanea = 0;
			scoreJogada = new SolidBrush[4];
			codigoSecreto = new SolidBrush[4];			
		}//botaoTerminar_Click

		private void buttonSairClassico_Click(object sender, System.EventArgs e)
		{
			this.radioButtonClient.Checked = false;
			this.radioButtonServer.Checked = false;
			this.radioButtonModo1.Checked = false;
			this.radioButtonModo2.Checked = false;
			this.panelEndIp.Visible = false;
			this.panelResultadosClassico.Visible = false;
			this.labelResultadosAdversario.Text = "";
			this.labelResultadosJogador.Text = "";
			this.panelInicial.Visible = true;				
			correUmaVez = false;			
			contadorBolas = 1;
			nJogada = 0;		
			jogosJogados = 0;
			codigoSecreto = new SolidBrush[4];
			tabuleiro = new Tabuleiro();
			tabScore = new TabuleiroScore();
			comClassica.fechaLigacao();		
		}

		
		private void botaoVoltarAjuda_Click(object sender, System.EventArgs e)
		{
			this.panelAjuda.Visible = false;
			
		}

		private void botaoAjuda_Click(object sender, System.EventArgs e)
		{
			this.panelAjuda.Visible = true;
		}

	

	
	}//Form1
}//namespace
