using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using Microsoft.ReportingServices.Interfaces;
using System.Text;
using System.Data.SqlClient;
using System.Linq;


namespace pharmacy
{

    public partial class Form1 : Form
    {
        OracleConnection conn;

        public Form1()
        {

            InitializeComponent();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {


        }



        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void OpenForm1(Form form)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            this.MaximizeBox = false;
            string conStr = "Data Source=localhost:1521/XE;User Id=PHARMACY;Password=hr;";
            conn = new OracleConnection(conStr);
            //this.reportViewer1.RefreshReport();
            PrintReport();
            LoadDistributors();
            LoadSalePerson();
            UpdateTotalBillLabelForToday();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            e_date.Value = e_date.Value.AddDays(1);
            m_date.Value = DateTime.Now;



            this.reportViewer2.RefreshReport();
        }
        

        private DataTable SearchMedicineInventory(string searchTerm)
        {
            if (conn.State != ConnectionState.Open) { conn.Open(); }
            DataTable dataTable = new DataTable();

            string query = "SELECT * FROM MEDECINEINVENTORY WHERE LOWER(Name) LIKE :searchTerm";

            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("searchTerm", "%" + searchTerm.ToLower() + "%"));
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);


                    adapter.Fill(dataTable);

                }
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); }
            return dataTable;
        }

        private void LoadData(DataGridView dataGridView)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); }

                // SQL query to fetch data
                string sql = "SELECT * FROM MEDECINEINVENTORY";

                OracleDataAdapter adapter = new OracleDataAdapter(sql, conn);

                //await adapter.FillAsync(dt);
                adapter.Fill(dt);

                dataGridView.DataSource = dt;
                dataGridView.Columns[0].Visible=false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:22 {ex.Message}");
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {


        }
        private void OpenForm2(Form form)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            returnpanel.Visible = false;
            salerecord.Visible = false;
            distributorpanel.Visible = false;
            billcheck.Visible = false;
            expiremedicine.Visible = false;
            saleperson.Visible = false;
            panel2.Visible = true;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
           


        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            salerecord.Visible = false;
            returnpanel.Visible = false;
            distributorpanel.Visible = false;
            billcheck.Visible = false;
            expiremedicine.Visible = false;
            saleperson.Visible = false;
            panel4.Visible = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            salerecord.Visible = false;
            returnpanel.Visible = false;
            distributorpanel.Visible = false;
            billcheck.Visible = false;
            expiremedicine.Visible = false;
            saleperson.Visible = false;
            panel5.Visible = true;
        }
        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void button26_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            returnpanel.Visible = false;
            distributorpanel.Visible = false;
            billcheck.Visible = false;
            expiremedicine.Visible = false;
            saleperson.Visible = false;
            salerecord.Visible = true;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            salerecord.Visible = false;
            distributorpanel.Visible = false;
            billcheck.Visible = false;
            expiremedicine.Visible = false;
            saleperson.Visible = false;
            returnpanel.Visible = true;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            salerecord.Visible = false;
            returnpanel.Visible = false;
            billcheck.Visible = false;
            expiremedicine.Visible = false;
            saleperson.Visible = false;
            distributorpanel.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            salerecord.Visible = false;
            returnpanel.Visible = false;
            distributorpanel.Visible = false;
            expiremedicine.Visible = false;
            saleperson.Visible = false;
            billcheck.Visible = true;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            salerecord.Visible = false;
            returnpanel.Visible = false;
            distributorpanel.Visible = false;
            billcheck.Visible = false;
            saleperson.Visible = false;
            expiremedicine.Visible = true;

        }

        private void button44_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            salerecord.Visible = false;
            returnpanel.Visible = false;
            distributorpanel.Visible = false;
            billcheck.Visible = false;
            expiremedicine.Visible = false;
            saleperson.Visible = true;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            expiremedicine.Visible = false;
            panel1.Visible = true;
            medicinesearc.Text = "";
            dataGridView7.DataSource = null;

            // Optionally clear rows if not using data binding
            dataGridView7.Rows.Clear();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            
        }
        private void button17_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
        }

        private bool ValidateInput()
        {
            // Validate namebox
            if (string.IsNullOrWhiteSpace(namebox.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(mg_box.Text))
            {
                MessageBox.Show("MG cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(p_pricebox.Text))
            {
                MessageBox.Show("Purchase Price cannot be empty.");
                return false;
            }

            if (!decimal.TryParse(p_pricebox.Text, out _))
            {
                MessageBox.Show("Purchase Price must in a number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(s_pricebox.Text))
            {
                MessageBox.Show("Sale Price cannot be empty.");
                return false;
            }
            // Validate p_pricebox
            if (!decimal.TryParse(s_pricebox.Text, out _))
            {
                MessageBox.Show("Sale Price must in a number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(unitbox.Text))
            {
                MessageBox.Show("Unit cannot be empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(unitequalsbox.Text))
            {
                MessageBox.Show("Enter how many pieces in one unit.");
                return false;
            }
            if (decimal.Parse(p_pricebox.Text) > decimal.Parse(s_pricebox.Text))
            {
                MessageBox.Show("Purchase price is not greater then sale price.");
                return false;
            }

            if (m_date.Value.Date >= e_date.Value.Date)
            {
                MessageBox.Show("Manufacture Date is not greater then Expiry Date .");
                return false;
            }

            return true;
        }

        private int getmedicinerows()
        {
            // SQL query to count rows
            string query = $"SELECT COUNT(*) FROM medecineinventory";

            int rowCount = 0;

            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); };
                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        rowCount = Convert.ToInt32(result);
                    }
                }
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) { conn.Close(); };
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); }

            return rowCount + 1;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            int serailno = getmedicinerows();
            decimal quantity = Convert.ToDecimal(unitbox.Text) * Convert.ToDecimal(unitequalsbox.Text);


            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); };

                // Prepare SQL INSERT statement
                string sql = "INSERT INTO MEDECINEINVENTORY (serialno, Name, Mg, Quantity, ManufactDate, ExpiryDate, PurchasePrice, SalePrice, BATCHNUMBER, unit, unitequals, total, DISTRIBUTORINFO) " +
                             "VALUES (:serialno, :name, :mg, :quantity, :manufactDate, :expiryDate, :purchasePrice, :salePrice, :batchnumber, :unit, :unitEquals, :total, :DISTRIBUTORINFO)";

                OracleCommand cmd = new OracleCommand(sql, conn);

                // Set parameters from your text fields
                cmd.Parameters.Add(":serialno", OracleDbType.Int32).Value = serailno;

                cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = namebox.Text;
                cmd.Parameters.Add(":mg", OracleDbType.Varchar2).Value = mg_box.Text;
                cmd.Parameters.Add(":quantity", OracleDbType.Decimal).Value = quantity;
                cmd.Parameters.Add(":manufactDate", OracleDbType.Date).Value = m_date.Value.Date;
                cmd.Parameters.Add(":expiryDate", OracleDbType.Date).Value = e_date.Value.Date;
                cmd.Parameters.Add(":purchasePrice", OracleDbType.Decimal).Value = Convert.ToDecimal(p_pricebox.Text);
                cmd.Parameters.Add(":salePrice", OracleDbType.Decimal).Value = Convert.ToDecimal(s_pricebox.Text);
                cmd.Parameters.Add(":batchnumber", OracleDbType.Varchar2).Value = batchbox.Text;
                cmd.Parameters.Add(":unit", OracleDbType.Decimal).Value = Convert.ToDecimal(unitbox.Text);
                cmd.Parameters.Add(":unitEquals", OracleDbType.Decimal).Value = Convert.ToDecimal(unitequalsbox.Text);
                decimal total = quantity * Convert.ToDecimal(p_pricebox.Text);
                cmd.Parameters.Add(":total", OracleDbType.Decimal).Value = total;
                cmd.Parameters.Add(":DISTRIBUTORINFO", OracleDbType.Varchar2).Value = distributorbox.Text;

                int rowsInserted = cmd.ExecuteNonQuery();

                if (rowsInserted > 0)
                {
                    MessageBox.Show("Medicine saved successfully.");
                    panel2clear();
                }
                else
                {
                    MessageBox.Show("Data insertion failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:9 " + ex.Message);
            }

            if (conn.State != ConnectionState.Closed) { conn.Close(); };
        }

        private void button13_Click(object sender, EventArgs e)
        {
        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

        private void searchmanage()
        {
            if (string.IsNullOrWhiteSpace(searchbox2.Text))
            {
                MessageBox.Show("Search cannot be empty.");
                return;
            }
            DataTable dataTable = SearchMedicineInventory(searchbox2.Text);
            //dataGridView3.AutoGenerateColumns = false;


            dataGridView3.Rows.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView3.Rows.Add(
                    row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12]
                );
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            searchmanage();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        int serialNo;
        private void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row selected.");
                return;
            }
            if (dataGridView3.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select one row.");
                return;
            }
            DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];
            serialNo = int.Parse(selectedRow.Cells[0].Value.ToString());
            nbox.Text = selectedRow.Cells[1].Value.ToString();
            mbox.Text = selectedRow.Cells[2].Value.ToString();
            qbox.Text = selectedRow.Cells[3].Value.ToString();
            mdate.Text = selectedRow.Cells[4].Value.ToString();
            edate.Text = selectedRow.Cells[5].Value.ToString();
            ppbox.Text = selectedRow.Cells[6].Value.ToString();
            spbox.Text = selectedRow.Cells[7].Value.ToString();
            bbox.Text = selectedRow.Cells[9].Value.ToString();


        }
        private void UpdateData(string name, string mg, int quantity, DateTime manufactDate, DateTime expiryDate, decimal purchasePrice, decimal salePrice, decimal total, string batchnumber)
        {

            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); };

                // SQL query to update data in MEDECINEINVENTORY table
                string sql = @"UPDATE MEDECINEINVENTORY 
                       SET Name = :name, 
                           Mg = :mg, 
                           Quantity = :quantity, 
                           ManufactDate = :manufactDate, 
                           ExpiryDate = :expiryDate, 
                           PurchasePrice = :purchasePrice, 
                           SalePrice = :salePrice, 
                           Total = :total,
                           BATCHNUMBER= :batchnumber
                       WHERE SerialNo = :serialNo";

                // Create OracleCommand
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    // Bind parameters
                    cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = name;
                    cmd.Parameters.Add(":mg", OracleDbType.Varchar2).Value = mg;
                    cmd.Parameters.Add(":quantity", OracleDbType.Int32).Value = quantity;
                    cmd.Parameters.Add(":manufactDate", OracleDbType.Date).Value = manufactDate;
                    cmd.Parameters.Add(":expiryDate", OracleDbType.Date).Value = expiryDate;
                    cmd.Parameters.Add(":purchasePrice", OracleDbType.Decimal).Value = purchasePrice;
                    cmd.Parameters.Add(":salePrice", OracleDbType.Decimal).Value = salePrice;
                    cmd.Parameters.Add(":total", OracleDbType.Decimal).Value = total;
                    cmd.Parameters.Add(":batchnumber", OracleDbType.Varchar2).Value = batchnumber;
                    cmd.Parameters.Add(":serialNo", OracleDbType.Int32).Value = serialNo;

                    // Execute the update
                    int rowsUpdated = cmd.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Data updated successfully.");
                        if (conn.State != ConnectionState.Closed) { conn.Close(); };
                        searchmanage();
                        updateclear();
                    }
                    else
                    {
                        MessageBox.Show("No rows updated. Check SerialNo exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error35 updating data: {ex.Message}");
            }


            if (conn.State != ConnectionState.Closed) { conn.Close(); };

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (!ValidateUpdateInput())
            {
                return;
            }

            string name = nbox.Text;
            string mg = mbox.Text;
            string batch = bbox.Text;
            int quantity = int.Parse(qbox.Text);
           // DateTime manufactDate = DateTime.Parse(mdate.Text);
            //DateTime expiryDate = DateTime.Parse(edate.Text);
            decimal purchasePrice = decimal.Parse(ppbox.Text);
            decimal salePrice = decimal.Parse(spbox.Text);
            decimal total = quantity * purchasePrice;
            UpdateData(name, mg, quantity, mdate.Value.Date, edate.Value.Date, purchasePrice, salePrice, total, batch);
        }

        private bool ValidateUpdateInput()
        {
            // Validate namebox
            if (string.IsNullOrWhiteSpace(nbox.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return false;
            }

            // Validate mg_box
            if (string.IsNullOrWhiteSpace(mbox.Text))
            {
                MessageBox.Show("MG cannot be empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(qbox.Text))
            {
                MessageBox.Show("Quantity cannot be empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(ppbox.Text))
            {
                MessageBox.Show("Purchase Price cannot be empty.");
                return false;
            }

            if (!decimal.TryParse(ppbox.Text, out _))
            {
                MessageBox.Show("Purchase Price must in a number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(spbox.Text))
            {
                MessageBox.Show("Sale Price cannot be empty.");
                return false;
            }
            // Validate p_pricebox
            if (!decimal.TryParse(spbox.Text, out _))
            {
                MessageBox.Show("Sale Price must in a number.");
                return false;
            }

            if (decimal.Parse(ppbox.Text) > decimal.Parse(spbox.Text))
            {
                MessageBox.Show("Purchase price is not greater then sale price.");
                return false;
            }

            if (mdate.Value > edate.Value)
            {
                MessageBox.Show("Manufacture Date is not greater then Expiry Date .");
                return false;
            }

            return true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            if (dataGridView3.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select one row to delete.");
                return;
            }
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?",
                     "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicked 'Yes', delete the row
                if (result == DialogResult.Yes)
                {
                    string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();

                    try
                    {
                        if (conn.State != ConnectionState.Open) { conn.Open(); };

                        string sql = "DELETE FROM MEDECINEINVENTORY WHERE SERIALNO = :id";
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.Parameters.Add(new OracleParameter("id", id));

                        int rowsDeleted = cmd.ExecuteNonQuery();

                        if (rowsDeleted > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");
                            if (conn.State != ConnectionState.Closed) { conn.Close(); }
                            dataGridView3.Rows.Clear();
                            searchmanage();
                        }
                        else
                        {
                            MessageBox.Show("No record deleted. Please check the selected row.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error:7" + ex.Message);
                    }
                }

                if (conn.State != ConnectionState.Closed) { conn.Close(); }

            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            updateclear();
            searchbox2.Text = "";
            dataGridView3.Rows.Clear();
        }

        private void updateclear()
        {
            nbox.Text = "";
            mbox.Text = "";
            qbox.Text = "";
            mdate.Text = "";
            edate.Text = "";
            ppbox.Text = "";
            spbox.Text = "";
            bbox.Text = "";

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void medicinebox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(medicinebox.Text))
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
            else
            {
                FilterMedicines(medicinebox.Text);
            }
        }

        private void FilterMedicines(string searchText)
        {
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); }

                string query = @"SELECT DISTINCT NAME
                             FROM MEDECINEINVENTORY
                             WHERE LOWER(NAME) LIKE :searchText AND EXPIRYDATE > SYSDATE";

                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    command.Parameters.Add(new OracleParameter("searchText", "%" + searchText.ToLower() + "%"));

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        //dataGridView1.DataSource = dataTable;
                        dataGridView1.Rows.Clear();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            dataGridView1.Rows.Add(row[0]);
                        }

                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }

                if (conn.State != ConnectionState.Closed) { conn.Close(); }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateMGComboBox(string medicineName)
        {
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); };

                // Define the query to get unique MG values based on the medicine name
                string query = @"SELECT DISTINCT MG
                            FROM MEDECINEINVENTORY
                            WHERE NAME = :medicineName AND EXPIRYDATE > SYSDATE";

                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    command.Parameters.Add(new OracleParameter("medicineName", medicineName));

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Clear the ComboBox and add new items
                        comboBoxMG.Items.Clear();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBoxMG.Items.Add(row["MG"].ToString());
                        }
                    }
                }

                if (conn.State != ConnectionState.Closed) { conn.Close(); };
            }
        }

        private void comboBoxMG_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(medicinebox.Text))
            {
                comboBoxMG.Items.Clear();
                comboBoxMG.Refresh();

            }
            else
            {
                UpdateMGComboBox(medicinebox.Text);
            }
        }

        private bool CheckMedicineAvailability()
        {
            bool available = false;
            {
                try
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); }

                    // Define SQL query as a string
                    string query = @"
                        SELECT SUM(Quantity) AS TotalQuantity
                        FROM Medecineinventory
                        WHERE name= :medicineName 
                        AND mg = :mgValue 
                        AND ExpiryDate > SYSDATE";

                    using (var command = new OracleCommand(query, conn))
                    {
                        command.Parameters.Add(new OracleParameter("medicineName", medicinebox.Text.Trim()));
                        command.Parameters.Add(new OracleParameter("mgValue", comboBoxMG.Text.Trim()));
                        object result = command.ExecuteScalar();
                        int totalQuantity = result != DBNull.Value && result != null ? Convert.ToInt32(result) : 0;
                        int requestedQuantity = Convert.ToInt32(quantitybox.Text.Trim());

                        if (totalQuantity >= requestedQuantity)
                        {
                            available = true;
                        }
                        else
                        {
                            available = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while accessing the database: " + ex.Message);
                }
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); }
            return available;
        }

        private bool CheckMedicineInDataGridView()
        {
            // Retrieve the values from input controls
            string medicineName = medicinebox.Text.Trim();
            string mgValue = comboBoxMG.Text.Trim();

            bool found = false;

            // Loop through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                // Check if the row's cells match the criteria
                if (row.Cells[1].Value != null &&
                    row.Cells[2].Value != null &&
                    row.Cells[1].Value.ToString().Trim() == medicineName &&
                    row.Cells[2].Value.ToString().Trim() == mgValue)
                {
                    found = true;
                    break;
                }

            }

            return found;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            namecheck();
        }

        private void namecheck()
        {
            string inputName = medicinebox.Text.Trim();
            bool nameFound = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(inputName, StringComparison.OrdinalIgnoreCase))
                {
                    nameFound = true;
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(medicinebox.Text))
            {
                MessageBox.Show("Medicine name empty.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nameFound == false)
            {
                MessageBox.Show("Medicine not found.");
                return;
            }
            if (string.IsNullOrWhiteSpace(quantitybox.Text))
            {
                MessageBox.Show("Quantity is empty.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (quantitybox.Text == "0")
            {
                MessageBox.Show("Invalid quantity.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool found = CheckMedicineInDataGridView();

            if (found == true)
            {
                MessageBox.Show("Medicine is already added.");
                return;
            }

            bool available = CheckMedicineAvailability();

            if (available == false)
            {
                MessageBox.Show("Insufficient quantity available.");
                return;
            }

            if (nameFound)
            {
                string name = medicinebox.Text;
                string mg = comboBoxMG.Text;

                int quantity;

                if (int.TryParse(quantitybox.Text, out quantity))
                {
                    var (saleprice, purchasePrice) = GetPricesFromDatabase(name, mg);
                    decimal price = saleprice;
                    decimal pprice = purchasePrice;
                    decimal purchaseprice = pprice * quantity;
                    decimal total = price * quantity;
                    dataGridView4.Rows.Add(null, name, mg, price, quantity, total, purchaseprice);
                    var result = payablecount();
                    payablebox.Text = result.Item1.ToString();
                    returnbox.Text = result.Item2.ToString();

                    if (string.IsNullOrWhiteSpace(receivedbox.Text) || receivedbox.Text == "0")
                    {
                        returnbox.Text = "";
                    }
                    medicinebox.Text = "";
                    comboBoxMG.SelectedIndex = -1;
                    comboBoxMG.Text = "";
                    quantitybox.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Name not found in the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (decimal salePrice, decimal purchasePrice) GetPricesFromDatabase(string name, string mg)
        {
            decimal salePrice = 0m;
            decimal purchasePrice = 0m;

            {
                try
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); };

                    string query = "SELECT SALEPRICE, PURCHASEPRICE FROM MEDECINEINVENTORY WHERE NAME = :name AND MG = :mg";

                    using (var command = new OracleCommand(query, conn))
                    {
                        command.Parameters.Add(new OracleParameter("name", name));
                        command.Parameters.Add(new OracleParameter("mg", mg));

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                salePrice = reader.GetDecimal(0);  // SALEPRICE
                                purchasePrice = reader.GetDecimal(1);  // PURCHASEPRICE
                            }
                        }
                    }
                }
                catch (OracleException ex)
                {
                    // Handle Oracle-specific exceptions
                    MessageBox.Show("Oracle database error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    MessageBox.Show("Error: " + ex.Message);
                }
                if (conn.State != ConnectionState.Closed) { conn.Close(); }

            }

            return (salePrice, purchasePrice);
        }


        private void dataGridView4_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                dataGridView4.Rows[e.RowIndex + i].Cells[0].Value = e.RowIndex + i + 1;
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            
        }
        private void button23_Click(object sender, EventArgs e)
        {
            PrintReport();
        }
        private DataTable GetDataFromDataGridView(DataGridView dgv)
        {
            DataTable dataTable = new DataTable();

            // Add columns to DataTable with CLS compliant names
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                // Replace spaces with underscores in column names
                string columnName = column.HeaderText.Replace(" ", "_");
                dataTable.Columns.Add(columnName);
            }

            // Add rows to DataTable
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }

        private DataTable GetDataFromDataGridView4(DataGridView dgv)
        {
            // Initialize a new DataTable
            DataTable dataTable = new DataTable();

            // Add columns to the DataTable
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (i != 2) // Add all columns except index 2
                {
                    string columnName = dgv.Columns[i].HeaderText.Replace(" ", "_");
                    dataTable.Columns.Add(columnName, typeof(object));
                }
            }

            // Populate the DataTable with data from the DataGridView
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Create a new DataRow
                    DataRow dataRow = dataTable.NewRow();

                    // Assign values to the DataRow
                    for (int i = 0, dataRowIndex = 0; i < dgv.Columns.Count; i++)
                    {
                        if (i == 1) // Merge column 1 and 2
                        {
                            var value1 = row.Cells[i].Value?.ToString() ?? string.Empty;
                            var value2 = row.Cells[2].Value?.ToString() ?? string.Empty;
                            dataRow[dataRowIndex] = $"{value1} {value2}".Trim();
                            dataRowIndex++;
                        }
                        else if (i != 2) // Skip adding column index 2 as it's merged with index 1
                        {
                            dataRow[dataRowIndex] = row.Cells[i].Value ?? DBNull.Value;
                            dataRowIndex++;
                        }
                    }

                    // Add the DataRow to the DataTable
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void quantitybox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void receivedbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void discountbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void taxbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            if (dataGridView4.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select one row to delete.");
                return;
            }

            if (dataGridView4.SelectedRows.Count > 0)
            {
                // Ask for confirmation before deleting
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicked 'Yes', delete the row
                if (result == DialogResult.Yes)
                {
                    dataGridView4.Rows.RemoveAt(dataGridView4.SelectedRows[0].Index);
                    //payablebox.Text = grossCount().ToString();
                    var results = payablecount();
                    payablebox.Text = results.Item1.ToString();
                    if (string.IsNullOrEmpty(receivedbox.Text))
                    {
                        returnbox.Text = null;
                    }
                    else
                    {
                        returnbox.Text = results.Item2.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Delete Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private decimal grossCount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (decimal.TryParse(row.Cells[5].Value?.ToString() ?? "0", out decimal cellValue))
                    {
                        sum += cellValue;
                    }
                }
            }
            return sum;
        }

        private decimal purchaseCount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (decimal.TryParse(row.Cells[6].Value?.ToString() ?? "0", out decimal cellValue))
                    {
                        sum += cellValue;
                    }
                }
            }
            return sum;
        }

        private (decimal, decimal) payablecount()
        {
            string received = receivedbox.Text;
            string sum = grossCount().ToString();
            string saletax = taxbox.Text;
            string discount = discountbox.Text;

            if (string.IsNullOrWhiteSpace(saletax))
            {
                saletax = 0.ToString();
            }
            if (string.IsNullOrWhiteSpace(discount))
            {
                discount = 0.ToString();
            }
            if (string.IsNullOrWhiteSpace(received))
            {
                received = 0.ToString();
            }

            decimal receivedAmount, sumAmount, saletaxAmount, discountAmount;
            decimal returnPayment, payable;


            bool isReceivedParsed = decimal.TryParse(received, out receivedAmount);
            bool isSumParsed = decimal.TryParse(sum, out sumAmount);
            bool isSaletaxParsed = decimal.TryParse(saletax, out saletaxAmount);
            bool isDiscountParsed = decimal.TryParse(discount, out discountAmount);


            payable = sumAmount + saletaxAmount;
            payable = payable - discountAmount;
            returnPayment = receivedAmount - payable;


            return (payable, returnPayment);
        }
        private void savedata()
        {
            int saleid = getsalesrows();
            decimal profit = purchaseCount();
            DateTime time = System.DateTime.Now;
            //string formattedDate = time.ToString("yyyy-MM-dd hh:mm:ss tt");

            string nameText = personbox.Text;
            string rowcount = dataGridView4.RowCount.ToString();
            string payment = paymentbox.Text;
            string sum = grossCount().ToString();
            string saletax = taxbox.Text;
            string discount = discountbox.Text;
            string received = receivedbox.Text;
            string returnpayment = returnbox.Text;
            string totalbill = payablebox.Text;
            if (string.IsNullOrWhiteSpace(saletax))
            {
                saletax = 0.ToString();
            }
            if (string.IsNullOrWhiteSpace(discount))
            {
                discount = 0.ToString();
            }
            if (string.IsNullOrWhiteSpace(received))
            {
                received = 0.ToString();
            }
            if (string.IsNullOrWhiteSpace(returnpayment))
            {
                returnpayment = 0.ToString();
            }
            if (string.IsNullOrWhiteSpace(totalbill))
            {
                totalbill = 0.ToString();
            }

            {
                decimal total = decimal.Parse(totalbill);
                profit = total - profit;
                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    string insertSalesQuery = @"
                INSERT INTO Sales (
                    SaleID, SalePerson, DateTimeSale, SubTotal, TotalItems, PaymentMode, SalesTax, ReceivedAmount, ReturnAmount, 
                    Discount, TotalBill, ProfitCount
                ) VALUES (
                    :SaleID, :SalePerson, :DateTimeSale,:SubTotal, :TotalItems, :PaymentMode, :SalesTax, :ReceivedAmount, :ReturnAmount, 
                    :Discount, :TotalBill, :ProfitCount
                )";
                    using (OracleCommand command = new OracleCommand(insertSalesQuery, conn))
                    {
                        command.Parameters.Add(new OracleParameter("SaleID", OracleDbType.Int32)).Value = int.Parse(saleid.ToString());
                        command.Parameters.Add(new OracleParameter("SalePerson", OracleDbType.Varchar2)).Value = nameText;
                        command.Parameters.Add(new OracleParameter("DateTimeSale", OracleDbType.Date)).Value = time;

                        command.Parameters.Add(new OracleParameter("SubTotal", OracleDbType.Decimal)).Value = decimal.Parse(sum);
                        command.Parameters.Add(new OracleParameter("TotalItems", OracleDbType.Int32)).Value = int.Parse(rowcount);
                        command.Parameters.Add(new OracleParameter("PaymentMode", OracleDbType.Varchar2)).Value = payment;
                        command.Parameters.Add(new OracleParameter("SalesTax", OracleDbType.Decimal)).Value = decimal.Parse(saletax);
                        command.Parameters.Add(new OracleParameter("ReceivedAmount", OracleDbType.Decimal)).Value = decimal.Parse(received);
                        command.Parameters.Add(new OracleParameter("ReturnAmount", OracleDbType.Decimal)).Value = decimal.Parse(returnpayment);
                        command.Parameters.Add(new OracleParameter("Discount", OracleDbType.Decimal)).Value = decimal.Parse(discount);
                        command.Parameters.Add(new OracleParameter("TotalBill", OracleDbType.Decimal)).Value = decimal.Parse(totalbill);
                        command.Parameters.Add(new OracleParameter("ProfitCount", OracleDbType.Decimal)).Value = decimal.Parse(profit.ToString());

                        command.ExecuteNonQuery();
                    }

                    setmedicnes(saleid);
                    PrintReport();
                    MessageBox.Show("Medicines sold successfully.");

                    DialogResult result = MessageBox.Show("Do you want to print bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        PrintReporte();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void PrintReporte()
        {

            try
            {
                bool hasPrinted = false;


                PageSettings pageSettings = new PageSettings();
                pageSettings.PaperSize = new PaperSize("Custom", 315, 1100);
                pageSettings.Margins = new Margins(0, 0, 0, 0);

                reportViewer1.SetPageSettings(pageSettings);

                reportViewer1.RenderingComplete += (sender, e) =>
                {
                    if (!hasPrinted)
                    {
                        reportViewer1.PrintDialog();
                        hasPrinted = true;
                    }
                };

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing the report: " + ex.Message);
            }
        }

        /*private void ExportReportToPDF()
        {
            try
            {
                string mimeType, encoding, fileNameExtension;
                Warning[] warnings;
                string[] streams;

                byte[] reportBytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                // Save the byte array to a file
                using (FileStream fs = new FileStream("report.pdf", FileMode.Create))
                {
                    fs.Write(reportBytes, 0, reportBytes.Length);
                }

                MessageBox.Show("Report exported successfully as PDF.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting the report: " + ex.Message);
            }
        }*/

        private int getsalesrows()
        {
            // SQL query to count rows
            string query = $"SELECT COUNT(*) FROM sales";

            int rowCount = 0;

            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); };
                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        rowCount = Convert.ToInt32(result);
                    }
                }
             }
            finally
            {
                if (conn.State != ConnectionState.Closed) { conn.Close(); }
            }
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

            return rowCount + 1;
        }

        private void setmedicnes(int saleId)
        {
            try
            {
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        // if (row.IsNewRow) continue;


                        string medicineName = row.Cells[1].Value.ToString();
                        string mg = row.Cells[2].Value.ToString();
                        decimal price = Convert.ToDecimal(row.Cells[3].Value);
                        int quantity = Convert.ToInt32(row.Cells[4].Value);
                        decimal total = Convert.ToDecimal(row.Cells[5].Value);
                        int qty = quantity;
                        string query = @"
                        INSERT INTO SALESMEDICINE (SALEID, MEDICINENAME,  PRICE, QUANTITY, TOTAL, qty)
                        VALUES (:saleId, :medicineName,  :price, :quantity, :total, :qty)";

                        using (OracleCommand command = new OracleCommand(query, conn))
                        {
                            command.Parameters.Add("saleId", saleId);
                            command.Parameters.Add("medicineName", medicineName + " " + mg);
                            command.Parameters.Add("price", price);
                            command.Parameters.Add("quantity", quantity);
                            command.Parameters.Add("total", total);
                            command.Parameters.Add("qty", qty);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView4.RowCount == 0)
            {
                MessageBox.Show("Medicine is not added.");
            }
            else
            {
                SellMedicineFromDataGridView();
                savedata();
                dataGridView4.Rows.Clear();
                dataGridView4.DataSource = null;
                payablebox.Text = null;
                returnbox.Text = null;
                taxbox.Text = null;
                discountbox.Text = null;
                receivedbox.Text = null;
                personbox.SelectedIndex = -1;
                personbox.Text = "";
                paymentbox.SelectedIndex = -1;
                paymentbox.Text = "";
                UpdateTotalBillLabelForToday();
            }


        }

        private void SellMedicineFromDataGridView()
        {
            bool allQuantitiesAvailable = true;
            List<Tuple<string, int, int>> updates = new List<Tuple<string, int, int>>(); // To store the serialNo, updated quantity, and updated unit

            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); }

                 //Check quantities
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the new row placeholder

                    string medicineName = row.Cells[1].Value.ToString();
                    string mg = row.Cells[2].Value.ToString();
                    int quantityToSell = Convert.ToInt32(row.Cells[4].Value);

                    // Check total quantity available
                    string totalQuantityQuery = @"
                    SELECT SUM(QUANTITY) AS TOTAL_QUANTITY
                    FROM MEDECINEINVENTORY
                    WHERE NAME = :medicineName AND MG = :mg AND EXPIRYDATE > SYSDATE";

                    using (OracleCommand cmd = new OracleCommand(totalQuantityQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("medicineName", medicineName));
                        cmd.Parameters.Add(new OracleParameter("mg", mg));

                        object result = cmd.ExecuteScalar();
                        int totalQuantityInStock = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                        if (quantityToSell > totalQuantityInStock)
                        {
                            MessageBox.Show($"Insufficient quantity available for {medicineName} {mg}. Aborting transaction.");
                            allQuantitiesAvailable = false;
                            break; // Exit the loop as one of the items is not available
                        }
                    }
                }

                if (!allQuantitiesAvailable)
                {
                    // Exit the method if quantities are not available
                    return;
                }

                // Process updates if all quantities are available
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the new row placeholder

                    string medicineName = row.Cells[1].Value.ToString();
                    string mg = row.Cells[2].Value.ToString();
                    int quantityToSell = Convert.ToInt32(row.Cells[4].Value);

                    // Fetch medicines with SERIALNO, sorted by expiry date
                    string detailQuery = @"
            SELECT SERIALNO, NAME, MG, QUANTITY, UNITEQUALS, EXPIRYDATE
            FROM MEDECINEINVENTORY
            WHERE NAME = :medicineName AND MG = :mg AND EXPIRYDATE > SYSDATE
            ORDER BY EXPIRYDATE ASC";

                    using (OracleCommand cmd = new OracleCommand(detailQuery, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("medicineName", medicineName));
                        cmd.Parameters.Add(new OracleParameter("mg", mg));

                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            int remainingQuantityToSell = quantityToSell;

                            foreach (DataRow dbRow in dt.Rows)
                            {
                                int availableQuantity = Convert.ToInt32(dbRow["QUANTITY"]);
                                int unitequals = Convert.ToInt32(dbRow["UNITEQUALS"]);
                                string serialNo = dbRow["SERIALNO"].ToString();

                                if (availableQuantity >= remainingQuantityToSell)
                                {
                                    // Prepare the update data
                                    int newQuantity = availableQuantity - remainingQuantityToSell;
                                    int newUnit = newQuantity / unitequals;
                                    updates.Add(new Tuple<string, int, int>(serialNo, newQuantity, newUnit));
                                    remainingQuantityToSell = 0;
                                    break;
                                }
                                else
                                {
                                    // Prepare the update data
                                    updates.Add(new Tuple<string, int, int>(serialNo, 0, 0));
                                    remainingQuantityToSell -= availableQuantity;
                                }
                            }

                            if (remainingQuantityToSell > 0)
                            {
                                MessageBox.Show($"Insufficient quantity available for {medicineName} {mg}. Skipping this item.");
                            }
                        }
                    }
                }

                // Apply all updates if successful
                if (allQuantitiesAvailable)
                {
                    foreach (var update in updates)
                    {
                        UpdateMedicineQuantityBySerialNo(update.Item1, update.Item2, update.Item3);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) { conn.Close(); }
            }
        }

        private void UpdateMedicineQuantityBySerialNo(string serialNo, int newQuantity, int newUnit)
        {
            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); }

                string updateQuery = @"
        UPDATE MEDECINEINVENTORY
        SET QUANTITY = :newQuantity,
            UNIT = :newUnit
        WHERE SERIALNO = :serialNo";

                using (OracleCommand cmd = new OracleCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("newQuantity", newQuantity));
                    cmd.Parameters.Add(new OracleParameter("newUnit", newUnit));
                    cmd.Parameters.Add(new OracleParameter("serialNo", serialNo));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the database: {ex.Message}");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) { conn.Close(); }
            }
        }

        private void receivedbox_KeyUp(object sender, KeyEventArgs e)
        {
            var result = payablecount();
            payablebox.Text = result.Item1.ToString();
            returnbox.Text = result.Item2.ToString();

            if (string.IsNullOrWhiteSpace(receivedbox.Text) || receivedbox.Text == "0")
            {
                returnbox.Text = "";
            }
        }

        private void taxbox_KeyUp(object sender, KeyEventArgs e)
        {
            var result = payablecount();
            payablebox.Text = result.Item1.ToString();
            returnbox.Text = result.Item2.ToString();

            if (string.IsNullOrWhiteSpace(receivedbox.Text) || receivedbox.Text == "0")
            {
                returnbox.Text = "";
            }
        }

        private void discountbox_KeyUp(object sender, KeyEventArgs e)
        {
            var result = payablecount();
            payablebox.Text = result.Item1.ToString();
            returnbox.Text = result.Item2.ToString();

            if (string.IsNullOrWhiteSpace(receivedbox.Text) || receivedbox.Text == "0")
            {
                returnbox.Text = "";
            }
        }


        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click_1(object sender, EventArgs e)
        {

        }

        private (decimal, decimal, decimal) Getprofitsale(string startdate, string enddate)
        {
            decimal totalProfit = 0;
            decimal totalBill = 0;
            decimal totaldiscount = 0;

            try
            {
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    // Define the SQL query
                    string query = "SELECT SUM(PROFITCOUNT) AS TotalProfit, SUM(TOTALBILL), SUM(DISCOUNT) AS TotalBill " +
                                   "FROM sales " +
                                   "WHERE TO_CHAR(DATETIMESALE, 'dd/MM/yyyy') BETWEEN :selectedDate AND :endDate";

                    using (OracleCommand command = new OracleCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.Add(new OracleParameter("selectedDate", startdate));
                        command.Parameters.Add(new OracleParameter("endDate", enddate));

                        // Execute the query and retrieve the sums
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the sums from the query results
                                if (!reader.IsDBNull(0))
                                    totalProfit = reader.GetDecimal(0);  // Assuming totalProfit is decimal
                                if (!reader.IsDBNull(1))
                                    totalBill = reader.GetDecimal(1);  // Assuming totalBill is decimal
                                if (!reader.IsDBNull(2))
                                    totaldiscount = reader.GetDecimal(2);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); }


            return (totalProfit, totalBill, totaldiscount);
        }
        private void button24_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Starting date is greater than Ending date");
                return;
            }
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            // Format the selected date to match the database format (dd/MM/yyyy)
            string formattedstartDate = startDate.ToString("dd/MM/yyyy");
            string formattedendDate = endDate.ToString("dd/MM/yyyy");

            // Execute the query and calculate the total profit
            (decimal totalProfit, decimal totalBill, decimal totalDiscount) = Getprofitsale(formattedstartDate, formattedendDate);

            totalprofit.Text = totalProfit.ToString(); // C for currency format
            totalsale.Text = totalBill.ToString();
            totaldiscount.Text = totalDiscount.ToString();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void unitequalsbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void unitbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void p_pricebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void s_pricebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void PrintReport()
        {
            reportViewer1.LocalReport.ReportPath = "bill.rdlc";

            DataTable dataTable = GetDataFromDataGridView4(dataGridView4);

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            DateTime time = System.DateTime.Now;

            int saleid = getsalesrows();
            saleid--;
            string nameText = personbox.Text;
            string dateTimeString = time.ToString();
            string rowcount = dataGridView4.RowCount.ToString();
            string payment = paymentbox.Text;
            string received = receivedbox.Text;
            string sum = grossCount().ToString();
            string saletax = taxbox.Text;
            string discount = discountbox.Text;
            string returnpayment = returnbox.Text;
            string payable = payablebox.Text;

            ReportParameter saleidParameter = new ReportParameter("saleid", saleid.ToString());
            ReportParameter nameParameter = new ReportParameter("saleperson", nameText);
            ReportParameter timeParameter = new ReportParameter("time", dateTimeString);
            ReportParameter rowsParameter = new ReportParameter("items", rowcount);
            ReportParameter paymentParameter = new ReportParameter("payment", payment.ToString());
            ReportParameter receivedParameter = new ReportParameter("paymentreceived", received.ToString());
            ReportParameter returnParameter = new ReportParameter("return", returnpayment);
            ReportParameter sumParameter = new ReportParameter("gross", sum);
            ReportParameter taxParameter = new ReportParameter("stax", saletax);
            ReportParameter discountParameter = new ReportParameter("discount", discount);
            ReportParameter payableParameter = new ReportParameter("payable", payable.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { saleidParameter, nameParameter, timeParameter,
                rowsParameter,  paymentParameter, receivedParameter, returnParameter, sumParameter, taxParameter,
                discountParameter, payableParameter});

            reportViewer1.RefreshReport();


        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void PrintReportDirectly2()
        {
            try
            {
                // Initialize and configure ReportViewer
                reportViewer1.LocalReport.ReportPath = "bill.rdlc";

                // Prepare the data source
                DataTable dataTable = GetDataFromDataGridView4(dataGridView4);
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Set parameters
                SetReportParameters();

                // Refresh the report
                reportViewer1.RefreshReport();

                // Render the report to an image
                byte[] reportBytes = RenderReportToImage();

                // Print the image with ReportViewer print settings
                PrintImageWithSettings(reportBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] RenderReportToImage()
        {
            try
            {
                string mimeType, encoding, fileNameExtension;
                Warning[] warnings;
                string[] streamIds;

                // Render the report to an image format
                return reportViewer1.LocalReport.Render("Image", null, out mimeType, out encoding, out fileNameExtension, out streamIds, out warnings);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while rendering the report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void PrintImageWithSettings(byte[] imageBytes)
        {
            if (imageBytes == null)
            {
                MessageBox.Show("Failed to render the report image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MemoryStream ms = new MemoryStream(imageBytes))
            using (Image image = Image.FromStream(ms))
            {
                PrintDocument printDoc = new PrintDocument
                {
                    PrinterSettings = { PrinterName = new PrinterSettings().PrinterName }
                };

                // Align print settings with ReportViewer's print settings
                var pageSettings = new PageSettings
                {
                    Margins = new Margins(0, 0, 0, 0), // Adjust margins as needed
                    PaperSize = new PaperSize("Custom", reportViewer1.LocalReport.GetDefaultPageSettings().PaperSize.Width, reportViewer1.LocalReport.GetDefaultPageSettings().PaperSize.Height),
                    Landscape = reportViewer1.LocalReport.GetDefaultPageSettings().IsLandscape
                };
                printDoc.DefaultPageSettings = pageSettings;

                printDoc.PrintPage += (sender, e) =>
                {
                    // Calculate scaling to fit the image within the page bounds
                    float scale = Math.Min(
                        (float)e.PageBounds.Width / image.Width,
                        (float)e.PageBounds.Height / image.Height);
                    float x = e.PageBounds.Left;
                    float y = e.PageBounds.Top;
                    float width = image.Width * scale;
                    float height = image.Height * scale;

                    // Draw the image without margins
                    e.Graphics.DrawImage(image, x, y, width, height);
                };

                try
                {
                    // Print the document
                    printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void SetReportParameters()
        {
            DateTime time = DateTime.Now;
            int saleid = getsalesrows();
            string nameText = personbox.Text;
            string dateTimeString = time.ToString();
            string rowcount = dataGridView4.RowCount.ToString();
            string payment = paymentbox.Text;
            string received = receivedbox.Text;
            string sum = grossCount().ToString();
            string saletax = taxbox.Text;
            string discount = discountbox.Text;
            string returnpayment = returnbox.Text;
            string payable = payablebox.Text;

            ReportParameter[] parameters = new ReportParameter[]
            {
        new ReportParameter("saleid", saleid.ToString()),
        new ReportParameter("saleperson", nameText),
        new ReportParameter("time", dateTimeString),
        new ReportParameter("items", rowcount),
        new ReportParameter("payment", payment.ToString()),
        new ReportParameter("paymentreceived", received.ToString()),
        new ReportParameter("return", returnpayment),
        new ReportParameter("gross", sum),
        new ReportParameter("stax", saletax),
        new ReportParameter("discount", discount),
        new ReportParameter("payable", payable.ToString())
            };
            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(returnsearch.Text))
            {
                MessageBox.Show("Search cannot be empty.");
                return;
            }
            returnsearching();
            //DataTable dataTable = returnsearching(returnsearch.Text);
        }

        private void returnsearching()
        {
            string searchTerm = returnsearch.Text;
            if (conn.State != ConnectionState.Open) { conn.Open(); }
            DataTable dataTable = new DataTable();

            string query = "SELECT 	SERIALNO,name,mg,quantity,manufactdate,expirydate,purchaseprice,saleprice FROM medecineinventory WHERE LOWER(Name) LIKE :searchTerm";

            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("searchTerm", "%" + searchTerm.ToLower() + "%"));
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);


                    adapter.Fill(dataTable);

                    dataGridView5.Rows.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        dataGridView5.Rows.Add(
                            row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]
                        );
                    }
                }
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); }
        }


        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                if (button28.Text == "Update")
                {
                    // Perform the update
                    int srno = int.Parse(returnserial.Text);
                    int quantity = int.Parse(returnquantity.Text);

                    // Call the function to update the medicine inventory
                    retrurnmedicine(srno, quantity);

                    // Show a success message
                    MessageBox.Show("Return medicine added successfully.");

                    returnname.Text = "";
                    returnmg.Text = "";
                    returnquantity.Text = "";
                    returnserial.Text = "";
                    returnsearching();

                    button28.Text = "Edit";

                }
                else
                {
                    // If not in Update mode, set text fields based on selected row
                    if (dataGridView5.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = dataGridView5.SelectedRows[0];

                        // Retrieve values from the selected row
                        returnserial.Text = selectedRow.Cells[0].Value.ToString();
                        returnname.Text = selectedRow.Cells[1].Value.ToString();
                        returnmg.Text = selectedRow.Cells[2].Value.ToString();

                        // Change the button text to "Update"
                        button28.Text = "Update";
                    }
                    else
                    {
                        MessageBox.Show("Please select a row to edit.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void button32_Click(object sender, EventArgs e)
        {
            /* int srno= int.Parse(returnserial.Text);
            int quantity = int.Parse(returnquantity.Text);
            retrurnmedicine(srno, quantity);*/
        }

        private void retrurnmedicine(int srno, int quantity)
        {

            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); };

                // SQL query to update data in MEDECINEINVENTORY table
                string sql = @"UPDATE MEDECINEINVENTORY 
                       SET 
                           Quantity = Quantity + :quantity
                       WHERE SerialNo = :serialNo";

                // Create OracleCommand
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":quantity", OracleDbType.Int32).Value = quantity;
                    cmd.Parameters.Add(":serialNo", OracleDbType.Int32).Value = srno;

                    // Execute the update
                    int rowsUpdated = cmd.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                    {
                        if (conn.State != ConnectionState.Closed) { conn.Close(); };
                    }
                    else
                    {
                        MessageBox.Show("No rows updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error35 updating data: {ex.Message}");
            }


            if (conn.State != ConnectionState.Closed) { conn.Close(); };

        }


        private void button31_Click(object sender, EventArgs e)
        {
            returnname.Text = "";
            returnmg.Text = "";
            returnquantity.Text = "";
            returnserial.Text = "";
            button28.Text = "Edit";

        }

        private void LoadDistributors()
        {
            {
                try
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); };

                    // Query to fetch DISTRIBUTORID and NAME from the DISTRIBUTORS table
                    string query = "SELECT DISTRIBUTORID, NAME FROM DISTRIBUTORS";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing items in ComboBox
                    distributorbox.Items.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        // Combine DISTRIBUTORID and NAME
                        string displayText = $"{row["NAME"]} - {row["DISTRIBUTORID"]}";

                        distributorbox.Items.Add(displayText);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

                if (conn.State != ConnectionState.Closed) { conn.Close(); };
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void returnpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void unitequalsbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void e_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(distributorname.Text))
            {
                MessageBox.Show("Name is empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(distributorcontact.Text))
            {
                MessageBox.Show("Contact is empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(distributoraddress.Text))
            {
                MessageBox.Show("Address is empty.");
                return;
            }
            distriutoradd();
            LoadDistributors();
        }
        private void UpdateTotalBillLabelForToday()
        {
            decimal totalBillSum = 0;

            try
            {
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); };
                    // Get the current system date
                    DateTime currentDate = DateTime.Now.Date;

                    // Query to sum the TOTALBILL column for today's date
                    string query = "SELECT SUM(TOTALBILL) FROM SALES WHERE TRUNC(DATETIMESALE) = :currentDate";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Add parameter to avoid SQL injection
                        cmd.Parameters.Add(new OracleParameter("currentDate", currentDate));

                        // Execute the query and get the sum
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            totalBillSum = Convert.ToDecimal(result);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            if (conn.State != ConnectionState.Closed) { conn.Close(); };
            today.Text = totalBillSum.ToString();
        }

        private void distriutoradd()
        {
            string name = distributorname.Text;
            string contact = distributorcontact.Text;
            string address = distributoraddress.Text;
            int newDistributorId;

            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); };
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); };
                    try
                    {
                        string countQuery = "SELECT MAX(DISTRIBUTORID) FROM DISTRIBUTORS";
                        OracleCommand countCommand = new OracleCommand(countQuery, conn);
                        int currentCount = Convert.ToInt32(countCommand.ExecuteScalar());
                        newDistributorId = currentCount + 1;
                    }
                    catch
                    {
                        newDistributorId = 0 + 1;
                    }

                    // Increment by 1 to get the new distributor ID


                    // Step 2: Insert the new distributor into the table
                    string insertQuery = @"
                    INSERT INTO DISTRIBUTORS (DISTRIBUTORID, NAME, PHONENUMBER, ADDRESS)
                    VALUES (:distributorId, :name, :contact, :address)";

                    using (OracleCommand insertCommand = new OracleCommand(insertQuery, conn))
                    {
                        // Add parameters to avoid SQL injection
                        insertCommand.Parameters.Add(new OracleParameter("distributorId", newDistributorId));
                        insertCommand.Parameters.Add(new OracleParameter("name", name));
                        insertCommand.Parameters.Add(new OracleParameter("contact", contact));
                        insertCommand.Parameters.Add(new OracleParameter("address", address));

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Distributor information saved successfully!");
                            distributorname.Text = "";
                            distributorcontact.Text = "";
                            distributoraddress.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Error saving distributor information.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); };
        }

        private void button35_Click(object sender, EventArgs e)
        {
            searchdisstributo();
        }

        private void searchdisstributo()
        {
            string searchText = searchdistributor.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a distributor name to search.");
                return;
            }

            try
            {
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); };

                    // Query to find distributors with names that match the search text
                    string query = @"
                    SELECT *
                    FROM DISTRIBUTORS
                    WHERE UPPER(NAME) LIKE UPPER(:searchText)";

                    using (OracleCommand command = new OracleCommand(query, conn))
                    {
                        // Add parameter to avoid SQL injection
                        command.Parameters.Add(new OracleParameter("searchText", "%" + searchText + "%"));

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView6.Rows.Clear();


                            foreach (DataRow row in dataTable.Rows)
                            {
                                dataGridView6.Rows.Add(
                                    row[0], row[1] + " - " + row[0], row[2], row[3]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); };

        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (dataGridView6.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView6.SelectedRows[0];
                    int distributorid = Convert.ToInt32(selectedRow.Cells[0].Value);

                    {
                        if (conn.State != ConnectionState.Open) { conn.Open(); };

                        // Delete the record from the database
                        string deleteQuery = "DELETE FROM DISTRIBUTORS WHERE distributorid = :distributorid";

                        using (OracleCommand command = new OracleCommand(deleteQuery, conn))
                        {
                            command.Parameters.Add(new OracleParameter("distributorid", distributorid));

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Remove the row from DataGridView
                                dataGridView6.Rows.Remove(selectedRow);
                                MessageBox.Show("Record deleted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Error deleting the record.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                if (conn.State != ConnectionState.Closed) { conn.Close(); };
            }
        }

        private void mg_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void mg_box_Leave(object sender, EventArgs e)
        {
            string text = mg_box.Text.Trim();

            text = Regex.Replace(text, "(?i)mg", "");

            text = text.Trim();

            mg_box.Text = text + "MG";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2clear();
        }
        private void panel2clear()
        {
            namebox.Text = "";
            mg_box.Text = "";
            distributorbox.SelectedIndex = -1;
            distributorbox.Text = "";
            batchbox.Text = "";
            p_pricebox.Text = "";
            s_pricebox.Text = "";
            unitbox.Text = "";
            unitequalsbox.Text = "";
            m_date.Value = DateTime.Now;
            e_date.Value = DateTime.Now;
        }

        private void deletedistriubutor()
        {
            if (dataGridView6.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            if (dataGridView6.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select one row to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Get the selected row
                        DataGridViewRow selectedRow = dataGridView6.SelectedRows[0];
                        int distributorId = Convert.ToInt32(selectedRow.Cells[0].Value); // Assuming DISTRIBUTORID is in the first column

                        {
                            if (conn.State != ConnectionState.Open) { conn.Open(); };

                            // Step 1: Delete the record
                            string deleteQuery = "DELETE FROM DISTRIBUTORS WHERE DISTRIBUTORID = :distributorId";

                            using (OracleCommand deleteCmd = new OracleCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.Add(new OracleParameter("distributorId", distributorId));

                                int rowsAffected = deleteCmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.");
                                    searchdisstributo();


                                }
                                else
                                {
                                    MessageBox.Show("Error deleting the record.");
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }

                }
                if (conn.State != ConnectionState.Closed) { conn.Close(); };
            }
        }
        private void button38_Click(object sender, EventArgs e)
        {
            deletedistriubutor();
            LoadDistributors();
        }

        private void button36_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click_1(object sender, EventArgs e)
        {
            distributorname.Text = "";
            distributorcontact.Text = "";
            distributoraddress.Text = "";
            searchdistributor.Text = "";
            dataGridView6.Rows.Clear();

        }

        private void distributorcontact_TextChanged(object sender, EventArgs e)
        {

        }

        private void distributorcontact_Click(object sender, EventArgs e)
        {

        }

        private void distributorcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void nbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void mdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ppbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void bbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void namebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void batchbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void s_pricebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void receivedbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure the click is not on the header row
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                medicinebox.Text = row.Cells[0].Value.ToString(); // Assuming the column name is "NAME"
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void quantitybox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void returnmg_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }



        private void returnquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void button34_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button36_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(billid.Text))
            {
                MessageBox.Show("Id is empty");
                return;
            }
            printbill();
        }

        private void printbill()
        {
            try
            {
                // Set the path for the RDLC report
                reportViewer2.LocalReport.ReportPath = "bill.rdlc";

                // Get the sale ID from the TextBox (assuming 'bill id' is the name of the TextBox)
                int saleid = int.Parse(billid.Text);

                // Retrieve data from SALESMEDICINE table based on saleid
                DataTable salesMedicineData = GetSalesMedicineData(saleid);
                //object firstElement = salesMedicineData.Rows[0][4];
                //MessageBox.Show($"First element of the third column: {firstElement}");

                // Retrieve additional data from SALES table based on saleid
                DataRow salesData = GetSalesData(saleid);

                // Bind the sales medicine data to the report
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", salesMedicineData);
                reportViewer2.LocalReport.DataSources.Clear();
                reportViewer2.LocalReport.DataSources.Add(reportDataSource);

                // Extract information from the salesData DataRow
                string nameText = salesData["SALEPERSON"].ToString();
                string dateTimeString = salesData["DATETIMESALE"].ToString();
                string rowcount = salesMedicineData.Rows.Count.ToString();
                string payment = salesData["PAYMENTMODE"].ToString();
                string received = salesData["RECEIVEDAMOUNT"].ToString();
                string sum = salesData["SUBTOTAL"].ToString();
                string saletax = salesData["SALESTAX"].ToString();
                string discount = salesData["DISCOUNT"].ToString();
                string returnpayment = salesData["RETURNAMOUNT"].ToString();
                string payable = salesData["TOTALBILL"].ToString();

                // Set the report parameters
                ReportParameter saleidParameter = new ReportParameter("saleid", saleid.ToString());
                ReportParameter nameParameter = new ReportParameter("saleperson", nameText);
                ReportParameter timeParameter = new ReportParameter("time", dateTimeString);
                ReportParameter rowsParameter = new ReportParameter("items", rowcount);
                ReportParameter paymentParameter = new ReportParameter("payment", payment);
                ReportParameter receivedParameter = new ReportParameter("paymentreceived", received);
                ReportParameter returnParameter = new ReportParameter("return", returnpayment);
                ReportParameter sumParameter = new ReportParameter("gross", sum);
                ReportParameter taxParameter = new ReportParameter("stax", saletax);
                ReportParameter discountParameter = new ReportParameter("discount", discount);
                ReportParameter payableParameter = new ReportParameter("payable", payable);

                reportViewer2.LocalReport.SetParameters(new ReportParameter[] {
            saleidParameter, nameParameter, timeParameter, rowsParameter,
            paymentParameter, receivedParameter, returnParameter, sumParameter,
            taxParameter, discountParameter, payableParameter
        });

                // Refresh the report to apply changes
                reportViewer2.RefreshReport();
            }
            catch (FormatException )
            {
                // Handle format exceptions, such as invalid integer parsing
                MessageBox.Show("Error parsing sale ID. Please enter a valid number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException )
            {
                // Handle SQL exceptions related to database access
                MessageBox.Show("An error occurred while retrieving data from the database. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DataTable GetSalesMedicineData(int saleid)
        {
            // Implement your logic to fetch data from SALESMEDICINE table based on saleid
            DataTable dataTable = new DataTable();

            string query = "SELECT * FROM SALESMEDICINE WHERE SALEID = :saleid";
            conn.Open();
            {
                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    command.Parameters.Add(new OracleParameter("saleid", saleid));

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            
            conn.Close();
            return dataTable;
        }

        private DataRow GetSalesData(int saleid)
        {
            // Implement your logic to fetch data from SALES table based on saleid
            DataTable salesTable = new DataTable();

            string query = "SELECT * FROM SALES WHERE SALEID = :saleid";
            conn.Open();
            {
                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    command.Parameters.Add(new OracleParameter("saleid", saleid));

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(salesTable);
                    }
                }
            }
            conn.Close();
            // Assuming only one row is returned since SALEID is unique
            return salesTable.Rows[0];
        }

        private void button40_Click(object sender, EventArgs e)
        {
            LoadExpiredMedicines();
            AdjustDataGridViewColumn();
        }
        private void LoadExpiredMedicines()
        {
            // Define the query to select expired medicines
            string query = "SELECT * FROM MEDECINEINVENTORY WHERE EXPIRYDATE < SYSDATE"; // Use SYSDATE for Oracle

            // Create a DataTable to hold the data
            DataTable expiredMedicinesTable = new DataTable();

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                // Create an OracleCommand to execute the query
                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    // Optionally, add parameters if needed
                    // command.Parameters.Add(new OracleParameter("parameter_name", parameter_value));

                    // Create an OracleDataAdapter to execute the command and fill the DataTable
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(expiredMedicinesTable);
                    }
                }

                // Bind the DataTable to the DataGridView
                dataGridView7.DataSource = expiredMedicinesTable;
                dataGridView7.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred while loading expired medicines: " + ex.Message);
            }
            finally
            {
                // Close the connection if it's still open
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            LoadNearExpiryMedicines();
            AdjustDataGridViewColumn();
        }
        private void LoadNearExpiryMedicines()
        {
            // Define the number of days to consider as "near expiry"
            int daysToExpiry = 30;

            // Define the query to select medicines near expiry
            string query = @"
        SELECT * 
        FROM MEDECINEINVENTORY 
        WHERE EXPIRYDATE BETWEEN SYSDATE AND SYSDATE + :daysToExpiry"; // Use SYSDATE for Oracle

            // Create a DataTable to hold the data
            DataTable nearExpiryTable = new DataTable();

            try
            {
                // Open the connection
                conn.Open();

                // Create an OracleCommand to execute the query
                using (OracleCommand command = new OracleCommand(query, conn))
                {
                    // Add parameter for the number of days to the command
                    command.Parameters.Add(new OracleParameter("daysToExpiry", daysToExpiry));

                    // Create an OracleDataAdapter to execute the command and fill the DataTable
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(nearExpiryTable);
                    }
                }

                // Sort the DataTable by EXPIRYDATE in ascending order
                nearExpiryTable.DefaultView.Sort = "EXPIRYDATE ASC";

                // Bind the DataTable to the DataGridView
                dataGridView7.DataSource = nearExpiryTable.DefaultView.ToTable();
                dataGridView7.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("An error occurred while loading near-expiry medicines: " + ex.Message);
            }
            finally
            {
                // Close the connection if it's still open
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void LoadSalePerson()
        {
            {
                try
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); };

                    // Query to fetch DISTRIBUTORID and NAME from the DISTRIBUTORS table
                    string query = "SELECT PERSONID, NAME FROM SALEPERSON";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Clear existing items in ComboBox
                    personbox.Items.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        // Combine DISTRIBUTORID and NAME
                        string displayText = $"{row["NAME"]} - {row["PERSONID"]}";

                        personbox.Items.Add(displayText);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

                if (conn.State != ConnectionState.Closed) { conn.Close(); };
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(personname.Text))
            {
                MessageBox.Show("Name is empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(personcontact.Text))
            {
                MessageBox.Show("Contact is empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(personaddress.Text))
            {
                MessageBox.Show("Address is empty.");
                return;
            }
            salepersonadd();
            LoadSalePerson();
        }

        private void salepersonadd()
        {
            string name = personname.Text;
            string contact = personcontact.Text;
            string address = personaddress.Text;
            int newsaleId;

            try
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); };
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); };
                    try
                    {
                        string countQuery = "SELECT MAX(PERSONID) FROM SALEPERSON";
                        OracleCommand countCommand = new OracleCommand(countQuery, conn);
                        int currentCount = Convert.ToInt32(countCommand.ExecuteScalar());
                        newsaleId = currentCount + 1;
                    }
                    catch
                    {
                        newsaleId = 0 + 1;
                    }

                    // Increment by 1 to get the new distributor ID


                    // Step 2: Insert the new distributor into the table
                    string insertQuery = @"
                    INSERT INTO SALEPERSON (PERSONID, NAME, PHONENUMBER, ADDRESS)
                    VALUES (:personId, :name, :contact, :address)";

                    using (OracleCommand insertCommand = new OracleCommand(insertQuery, conn))
                    {
                        // Add parameters to avoid SQL injection
                        insertCommand.Parameters.Add(new OracleParameter("personId", newsaleId));
                        insertCommand.Parameters.Add(new OracleParameter("name", name));
                        insertCommand.Parameters.Add(new OracleParameter("contact", contact));
                        insertCommand.Parameters.Add(new OracleParameter("address", address));

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Distributor information saved successfully!");
                            personname.Text = "";
                            personcontact.Text = "";
                            personaddress.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Error saving distributor information.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); };
        }

        private void button48_Click(object sender, EventArgs e)
        {
            searchsaleperson();
            LoadSalePerson();
        }

        private void searchsaleperson()
        {
            string searchText = searchperson.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a Person name to search.");
                return;
            }

            try
            {
                {
                    if (conn.State != ConnectionState.Open) { conn.Open(); };

                    // Query to find distributors with names that match the search text
                    string query = @"
            SELECT *
            FROM SALEPERSON
            WHERE UPPER(NAME) LIKE UPPER(:searchText)";

                    using (OracleCommand command = new OracleCommand(query, conn))
                    {
                        // Add parameter to avoid SQL injection
                        command.Parameters.Add(new OracleParameter("searchText", "%" + searchText + "%"));

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView8.Rows.Clear();


                            foreach (DataRow row in dataTable.Rows)
                            {
                                dataGridView8.Rows.Add(
                                    row[0], row[1] + " - " + row[0], row[2], row[3]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            if (conn.State != ConnectionState.Closed) { conn.Close(); };

        }

        private void button47_Click(object sender, EventArgs e)
        {
            deleteperson();
            LoadSalePerson();
        }

        private void deleteperson()
        {
            if (dataGridView8.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            if (dataGridView8.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select one row to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Get the selected row
                        DataGridViewRow selectedRow = dataGridView8.SelectedRows[0];
                        int personId = Convert.ToInt32(selectedRow.Cells[0].Value); // Assuming DISTRIBUTORID is in the first column

                        {
                            if (conn.State != ConnectionState.Open) { conn.Open(); };

                            // Step 1: Delete the record
                            string deleteQuery = "DELETE FROM SALEPERSON WHERE PERSONID = :personId";

                            using (OracleCommand deleteCmd = new OracleCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.Add(new OracleParameter("personId", personId));

                                int rowsAffected = deleteCmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.");
                                    searchsaleperson();


                                }
                                else
                                {
                                    MessageBox.Show("Error deleting the record.");
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }

                }
                if (conn.State != ConnectionState.Closed) { conn.Close(); };
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            personname.Text = "";
            personcontact.Text = "";
            personaddress.Text = "";
            searchperson.Text = "";
            dataGridView8.Rows.Clear();
        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void panel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button43_Click(object sender, EventArgs e)
        {
            LoadData(dataGridView7);
            AdjustDataGridViewColumn();
        }
        private void AdjustDataGridViewColumn()
        {
            dataGridView7.Columns[0].Visible = false;
            int width=150;
            foreach (DataGridViewColumn column in dataGridView7.Columns)
            {
                column.Width = width;  // Set the width to 200 pixels
            }
        }


        private void searchMedicine(string searchText)
        {
            // Check if dataGridView1 already has data
            if (dataGridView7.DataSource != null)
            {
                DataTable dt = (DataTable)dataGridView7.DataSource;  // Get current data source

                // Use LINQ to filter the data (or adjust for your search logic)
                var filteredRows = dt.AsEnumerable()
                                     .Where(row => row.Field<string>("Name").ToLower().Contains(searchText.ToLower()));

                // If matches are found, load them back into the DataGridView
                if (filteredRows.Any())
                {
                    dataGridView7.DataSource = filteredRows.CopyToDataTable();
                }
                else
                {
                    MessageBox.Show("No matching data found.");
                }
            }
            else
            {
                MessageBox.Show("No data available to search. Load data first.");
            }
        }
        private void button7_Click_2(object sender, EventArgs e)
        {
              // If DataGridView already has data, perform search based on TextBox input
            {
                string searchText = medicinesearc.Text;  // Get the search text
                searchMedicine(searchText);  // Perform the search/filter
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            billcheck.Visible = false;
            panel1.Visible = true;
            billid.Text = "";
            reportViewer2.LocalReport.DataSources.Clear(); // Clears any existing data sources
            reportViewer2.LocalReport.ReportEmbeddedResource = ""; // Clears the embedded report resource
            reportViewer2.RefreshReport();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            panel2clear();
        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel1.Visible = true;
            updateclear();
            searchbox2.Text = "";
            dataGridView3.Rows.Clear();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel1.Visible = true;
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            returnpanel.Visible = false;
            panel1.Visible = true;
            returnname.Text = "";
            returnmg.Text = "";
            returnquantity.Text = "";
            returnserial.Text = "";
            returnsearch.Text = "";
            button28.Text = "Edit";
            dataGridView5.Rows.Clear();
        }

        private void button21_Click_2(object sender, EventArgs e)
        {
            salerecord.Visible = false;
            panel1.Visible = true;
            totalprofit.Text = "0";
            totalsale.Text = "0";
            totaldiscount.Text = "0";
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            saleperson.Visible = false;
            panel1.Visible = true;
            personname.Text = "";
            personcontact.Text = "";
            personaddress.Text = "";
            searchperson.Text = "";
            dataGridView8.Rows.Clear();
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            distributorpanel.Visible = false;
            panel1.Visible = true;
            distributorname.Text = "";
            distributorcontact.Text = "";
            distributoraddress.Text = "";
            searchdistributor.Text = "";
            dataGridView6.Rows.Clear();
        }

        private void mbox_Leave(object sender, EventArgs e)
        {
            string text = mbox.Text.Trim();

            text = Regex.Replace(text, "(?i)mg", "");

            text = text.Trim();

            mbox.Text = text + "MG";
        }

        private void personcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void billid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void qbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Suppress the key press event so the character is not entered
                e.Handled = true;
            }
        }

        private void ppbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }

        private void spbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Suppress the key press event if the character is not valid
            }
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains("."))
            {
                e.Handled = true; // Suppress the key press event if a second decimal point is entered
            }
        }
    }
}
