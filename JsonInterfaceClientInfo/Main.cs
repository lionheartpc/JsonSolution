using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonInterfaceClientInfo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private string openJson()
        {
            string jsonContents = "";
            System.IO.Stream filestream;
            OpenFileDialog openFileDialogJson = new OpenFileDialog();
            openFileDialogJson.Filter = "json files (*.json)|*.json";
            if (openFileDialogJson.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((filestream = openFileDialogJson.OpenFile()) != null)
                {
                   jsonContents = System.IO.File.ReadAllText(openFileDialogJson.FileName);

                }
            }
            return jsonContents;
        }

        private void openJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json =openJson();

            using (SqlConnection sqlCon = new SqlConnection(GetConnectionStringByName("JsonInterfaceClientInfo.Properties.Settings.ClientConnectionString")))
            {

                using (SqlCommand cmd = new SqlCommand("client.LoadJsonToProcessing", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@JsonContents", json);

                    sqlCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Imported");
                }
            }
        }

        private void showDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            refreshGridAddress();


        }

        private void refreshGridAddress()
        {

            using (SqlConnection sqlCon = new SqlConnection(GetConnectionStringByName("JsonInterfaceClientInfo.Properties.Settings.ClientConnectionString")))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT [Id],[name],[address],[postalCode]FROM [client].[Address]", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDA.Fill(dtbl);
                sqlCon.Close();
                dataGridViewAddress.DataSource = dtbl;

                dataGridViewAddress.Refresh();
            }

            

        }

        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        private void updatePostalCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(GetConnectionStringByName("JsonInterfaceClientInfo.Properties.Settings.ClientConnectionString")))
            {

                using (SqlCommand cmd = new SqlCommand("client.cursorAndUpdateAllPostalCodes", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ApiKey", ConfigurationManager.AppSettings["ApiKey"]);
                    cmd.Parameters.AddWithValue("@ApiUrl", ConfigurationManager.AppSettings["ApiURL"]);
                    sqlCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                }
            }
            refreshGridAddress();
        }
    }
}
