using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EPDM.Interop.epdm;
using Microsoft.VisualBasic;

/*
*  Marcos:
*  Alternar inicialização de Custom em Program.cs - ver nota
*  
*  19/03/18 - TextBoxUpper(...) foi refatorado
*           - Convensões de nomenclaturas foi normalizada
*           - Comentários para documentação foram inseridos
*           - Métodos do App Exemplo foram incluídos temporáriamente
*/

namespace CustomCardView_CSharp
{
    public partial class Custom : Form, IEdmCardViewCallback6
    {
        /* Interface do Usuário
         * 
         * Métodos de interação com a Interface do Usuário
         */

        public Custom()
        {
            InitializeComponent();
        }

        private void TextBoxUpper(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int start = textBox.SelectionStart;
            textBox.Text = textBox.Text.ToUpper();
            textBox.SelectionStart = start;
        }

        // Método incluído como exemplo
        public void Form1_Load(System.Object sender, System.EventArgs e)
        {
            /*
            try
            {
                vault1 = new EdmVault5();
                IEdmVault10 vault = (IEdmVault10)vault1;
                EdmViewInfo[] Views = null;

                vault.GetVaultViews(out Views, false);
                //VaultsComboBox.Items.Clear();

                foreach (EdmViewInfo View in Views)
                {
                   VaultsComboBox.Items.Add(View.mbsVaultName);
                }
                if (VaultsComboBox.Items.Count > 0)
                {
                    VaultsComboBox.Text = (string)VaultsComboBox.Items[0];
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        // Método incluído como exemplo
        public void SelectFile_Click(System.Object sender, System.EventArgs e)
        {
            /*
            try
            {
                File1List.Items.Clear();

                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }

                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                //Set the initial directory in the Select File dialog
                OpenFileDialog1.InitialDirectory = vault1.RootFolderPath;

                //Show the Select File dialog
                System.Windows.Forms.DialogResult DialogResult;
                DialogResult = OpenFileDialog1.ShowDialog();

                if (!(DialogResult == System.Windows.Forms.DialogResult.OK))
                {
                    // do nothing
                }
                else
                {
                    foreach (string FileName in OpenFileDialog1.FileNames)
                    {
                        File1List.Items.Add(FileName);
                        aFile = (IEdmFile7)vault1.GetFileFromPath(FileName, out aFolder);
                        ShowCard(aFolder, aFile.ID);
                    }
                }

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        // Método incluído como exemplo
        public void SaveCard_Click(System.Object sender, System.EventArgs e)
        {
            /*
            try
            {
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }

                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                view.SaveData();
                SaveCard.Enabled = false;

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        // Método incluído como exemplo
        //Display the card of the selected file
        private void ShowCard(IEdmFolder5 folder, int fileID)
        {
            /*
            try
            {
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }

                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }
                IEdmVault10 vault = (IEdmVault10)vault1;

                EdmCardViewParams @params = default(EdmCardViewParams);
                @params.mlFileID = fileID;
                @params.mlFolderID = folder.ID;
                @params.mlCardID = 0;
                @params.mlX = 40;
                @params.mlY = 300;
                @params.mhParentWindow = this.Handle.ToInt32();
                @params.mlEdmCardViewFlags = (int)EdmCardViewFlag.EdmCvf_Normal;

                //Create the card view interface 
                view = vault.CreateCardViewEx2(@params, this);

                if (view == null)
                {
                    Interaction.MsgBox("The file does not have a card.");
                    return;
                }

                //Set input focus to the first control in the card
                view.SetFocus(0);

                //Enable all controls in the card
                view.Update(EdmCardViewUpdateType.EdmCvut_EnableCtrl);

                //Get the size needed to display the card 
                int width = 0;
                int height = 0;
                view.GetCardSize(out width, out height);

                //Resize the form window to make room for the card 
                this.Width = (width + 100);
                this.Height = (height + 400);
                view.ShowWindow(true);

                SaveCard.Enabled = false;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        /* PDM
         * 
         * Métodos incubidos de atender os requisitos para integração
         * com o sistema PDM
         */

        private IEdmVault5 vault1;
        private IEdmCardView63 view;
        private IEdmFile7 aFile;
        private IEdmFolder5 aFolder;

        private void EdmCardViewCallback6_SetModifiedFlag()
        {
            //SaveCard.Enabled = true; //alt
        }

        void IEdmCardViewCallback6.SetModifiedFlag()
        {
            EdmCardViewCallback6_SetModifiedFlag();
        }

        private void EdmCardViewCallback6_OnAddInInput(int lFlags)
        {
        }

        void IEdmCardViewCallback6.OnAddInInput(int lFlags)
        {
            EdmCardViewCallback6_OnAddInInput(lFlags);
        }

        private void EdmCardViewCallback6_SetCtrlData(int lCardWnd, int lCardID, int lControlID, int lVariableID, string bsVariableName, IEdmCardView5 poView, ref object poValue)
        {
            try
            {
                if (bsVariableName == "Comment")
                {
                    Interaction.MsgBox(lCardWnd + " " + lCardID + " " + lControlID + " " + lVariableID + " " + bsVariableName + " " + poValue.ToString());

                    IEdmEnumeratorVariable5 enumvar = default(IEdmEnumeratorVariable5);
                    enumvar = aFile.GetEnumeratorVariable();

                    enumvar.SetVar(bsVariableName, "", poValue, true);
                    enumvar.Flush();
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void IEdmCardViewCallback6.SetCtrlData(int lCardWnd, int lCardID, int lControlID, int lVariableID, string bsVariableName, IEdmCardView5 poView, ref object poValue)
        {
            EdmCardViewCallback6_SetCtrlData(lCardWnd, lCardID, lControlID, lVariableID, bsVariableName, poView, ref poValue);
        }

        private object EdmCardViewCallback6_GetCtrlData(int lCardWnd, int lCardID, int lControlID, int lVariableID, string bsVariableName, IEdmCardView5 poView)
        {
            Interaction.MsgBox(lCardWnd + " " + lCardID + " " + lControlID + " " + lVariableID + " " + bsVariableName + " " + poView.ToString()); //alt
            return null;
        }

        object IEdmCardViewCallback6.GetCtrlData(int lCardWnd, int lCardID, int lControlID, int lVariableID, string bsVariableName, IEdmCardView5 poView)
        {
            return EdmCardViewCallback6_GetCtrlData(lCardWnd, lCardID, lControlID, lVariableID, bsVariableName, poView);
        }

        private object EdmCardViewCallback6_GetDefaultValueComponent(EdmDefValComp eValue)
        {
            return null;
        }

        object IEdmCardViewCallback6.GetDefaultValueComponent(EdmDefValComp eValue)
        {
            return EdmCardViewCallback6_GetDefaultValueComponent(eValue);
        }

        /* Banco de dados  
         * 
         * Métodos preparados para migrar para outras classes, para atender
         * a metodologia em camadas de forma a manter o códico coeso e mais
         * simples de tratar, mas que ainda  não foi  desdobrado por razões
         * da fase atual de desenvolvimento.
         * 
         * SSP
         */

// Métodos para conexão com Sistema de Banco de Dados Esfecífico. (Estão funcionando com SQL Server 2012)

        private SqlConnection dbcon;
        private SqlCommand dbcmd;

        private void ToConnect()
        {
            string server;
            //string timeout;
            string database;
            string user;
            //string password;

            try
            {
                // Deve ser configurado ou implementado uma interface na fase de implementação.
                server = "desktop-m8ila7h\\sqlexpress";
                database = "Ouro Negro";
                user = "True";

                string connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security={2};", server, database, user);

                dbcon = new SqlConnection(connectionString);
                dbcon.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao tentar conectar ao banco de dados do sistema! - Especificação: " + e.Message);
            }
        }

        public void CommandSql(string sql, string msgFalha)
        {
            try
            {
                ToConnect();

                dbcmd = dbcon.CreateCommand();
                dbcmd.CommandText = sql;
                dbcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(msgFalha + " - Especificação: " + ex.Message);
            }
            finally
            {
                CleanCom();
                CleanCon();
            }
        }

        public DataTable ReadDataTable(string sql, string msgFalha)
        {
            try
            {
                ToConnect();

                SqlCommand com = new SqlCommand(sql, dbcon);
                com.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(com);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(msgFalha + " - Especificação: " + ex.Message);
            }
            finally
            {
                CleanCon();
            }
        }

        public string ReadString(string sql, string msgFalha)
        {
            try
            {
                string dado;

                ToConnect();

                SqlCommand com = new SqlCommand(sql, dbcon);

                com.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(com);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dado = dt.Rows[0][0].ToString();

                return dado;
            }
            catch (Exception ex)
            {
                throw new Exception(msgFalha + " - Especificação: " + ex.Message);
            }
        }

        private void CleanCon()
        {
            dbcon.Close();
            dbcon = null;
        }

        private void CleanCom()
        {
            dbcmd.Dispose();
            dbcmd = null;
        }

        // Métodos de tratamento de dados. (Estão funcionado, mas precisam ser adaptados a necessidade da aplicação)

        public string AllTags()
        {
            string sql = "SELECT tag, note FROM tag " +
                         "ORDER BY tag";

            string falha = "Falha ao tentar consultar a tabela tag no banco de dados!";

            return ReadString(sql, falha);
        }

        public string LastTag(string value)
        {
            string sql, falha;

            sql = "USE [Ouro Negro] " +
                  "SELECT tag " +
                  "FROM dbo.tag "+
                  "WHERE tag >= '"+ value +"';";

            falha = "Ocorreu uma falha ao tentar consultar a sequência da tag no banco de dados!";

            return ReadString(sql, falha);
        }

        private void InsertTag(string tag)
        {
            string sql, falha;

            sql = "INSERT INTO dbo.tag (tag) VALUES('" + tag+"');";

            falha = "Ocorreu uma falha ao tentar inserir uma tag no banco de dados!";

            CommandSql(sql, falha);
        }
    }
}
