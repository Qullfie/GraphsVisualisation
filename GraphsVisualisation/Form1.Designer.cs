namespace GraphsVisualisation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            addNodeBtn = new Button();
            addNodeTB = new TextBox();
            fromTB = new TextBox();
            label1 = new Label();
            toTB = new TextBox();
            addEdgeBtn = new Button();
            MainPictureBox = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            maxMultTB = new TextBox();
            maxMultBtn = new Button();
            label2 = new Label();
            saveBtn = new Button();
            loadBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).BeginInit();
            SuspendLayout();
            // 
            // addNodeBtn
            // 
            addNodeBtn.Location = new Point(718, 127);
            addNodeBtn.Name = "addNodeBtn";
            addNodeBtn.Size = new Size(143, 31);
            addNodeBtn.TabIndex = 3;
            addNodeBtn.Text = "Добавить узел";
            addNodeBtn.UseVisualStyleBackColor = true;
            addNodeBtn.Click += addNodeBtn_Click;
            // 
            // addNodeTB
            // 
            addNodeTB.Location = new Point(718, 94);
            addNodeTB.Name = "addNodeTB";
            addNodeTB.Size = new Size(141, 27);
            addNodeTB.TabIndex = 4;
            addNodeTB.Tag = "Значение";
            // 
            // fromTB
            // 
            fromTB.Location = new Point(718, 20);
            fromTB.Name = "fromTB";
            fromTB.Size = new Size(55, 27);
            fromTB.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(780, 24);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 6;
            label1.Text = "->";
            label1.Click += label1_Click;
            // 
            // toTB
            // 
            toTB.Location = new Point(804, 21);
            toTB.Name = "toTB";
            toTB.Size = new Size(57, 27);
            toTB.TabIndex = 7;
            // 
            // addEdgeBtn
            // 
            addEdgeBtn.Location = new Point(718, 48);
            addEdgeBtn.Name = "addEdgeBtn";
            addEdgeBtn.Size = new Size(143, 31);
            addEdgeBtn.TabIndex = 8;
            addEdgeBtn.Text = "Добавить дугу";
            addEdgeBtn.UseVisualStyleBackColor = true;
            addEdgeBtn.Click += addEdgeBtn_Click;
            // 
            // MainPictureBox
            // 
            MainPictureBox.BorderStyle = BorderStyle.FixedSingle;
            MainPictureBox.Location = new Point(14, 17);
            MainPictureBox.Margin = new Padding(3, 4, 3, 4);
            MainPictureBox.Name = "MainPictureBox";
            MainPictureBox.Size = new Size(698, 576);
            MainPictureBox.TabIndex = 9;
            MainPictureBox.TabStop = false;
            MainPictureBox.Paint += MainPictureBox_Paint;
            MainPictureBox.MouseDown += MainPictureBox_MouseDown;
            MainPictureBox.MouseMove += MainPictureBox_MouseMove;
            MainPictureBox.MouseUp += MainPictureBox_MouseUp;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // maxMultTB
            // 
            maxMultTB.Location = new Point(718, 295);
            maxMultTB.Multiline = true;
            maxMultTB.Name = "maxMultTB";
            maxMultTB.Size = new Size(175, 103);
            maxMultTB.TabIndex = 10;
            // 
            // maxMultBtn
            // 
            maxMultBtn.Location = new Point(718, 404);
            maxMultBtn.Name = "maxMultBtn";
            maxMultBtn.Size = new Size(175, 29);
            maxMultBtn.TabIndex = 11;
            maxMultBtn.Text = "Рассчитать кратность";
            maxMultBtn.UseVisualStyleBackColor = true;
            maxMultBtn.Click += maxMultBtn_Click;
            // 
            // label2
            // 
            label2.Location = new Point(718, 245);
            label2.Name = "label2";
            label2.Size = new Size(175, 43);
            label2.TabIndex = 12;
            label2.Text = "Поиск максимальной кратности";
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(718, 504);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(177, 29);
            saveBtn.TabIndex = 13;
            saveBtn.Text = "Сохранить в файл";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // loadBtn
            // 
            loadBtn.Location = new Point(718, 551);
            loadBtn.Name = "loadBtn";
            loadBtn.Size = new Size(176, 28);
            loadBtn.TabIndex = 14;
            loadBtn.Text = "Загрузить из файла";
            loadBtn.UseVisualStyleBackColor = true;
            loadBtn.Click += loadBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 606);
            Controls.Add(loadBtn);
            Controls.Add(saveBtn);
            Controls.Add(label2);
            Controls.Add(maxMultBtn);
            Controls.Add(maxMultTB);
            Controls.Add(MainPictureBox);
            Controls.Add(addEdgeBtn);
            Controls.Add(toTB);
            Controls.Add(label1);
            Controls.Add(fromTB);
            Controls.Add(addNodeTB);
            Controls.Add(addNodeBtn);
            Name = "Form1";
            Tag = "";
            Text = "Graph";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)MainPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addNodeBtn;
        private TextBox addNodeTB;
        private TextBox fromTB;
        private Label label1;
        private TextBox toTB;
        private Button addEdgeBtn;
        private PictureBox MainPictureBox;
        private System.Windows.Forms.Timer timer1;
        private TextBox maxMultTB;
        private Button maxMultBtn;
        private Label label2;
        private Button saveBtn;
        private Button loadBtn;
    }
}