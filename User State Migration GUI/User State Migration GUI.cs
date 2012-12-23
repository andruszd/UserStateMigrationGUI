using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Diagnostics;

namespace User_State_Migration_GUI
{
    public partial class UserSateMigationGUI : Form
    {
        public UserSateMigationGUI()
        {
           
            InitializeComponent();
            eventLog.WriteEntry("Starting User State Migation GUI");
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            eventLog.WriteEntry("Exiting User Sate Migration GUI");
            System.Environment.Exit(0);
        }

        private void UserSateMigationGUI_Load(object sender, EventArgs e)
        {
            //List of All local users on the Machine and add them to the listbox
            var path = string.Format("WinNT://{0},computer", Environment.MachineName);
            using (var computerEntry = new DirectoryEntry(path))
            {
                var userNames = from DirectoryEntry childEntry in computerEntry.Children
                                where childEntry.SchemaClassName == "User"
                                select childEntry.Name;

                foreach (var name in userNames)
                    //User_listBox.Items.Add(name);
                    Users_local_checkedListBox.Items.Add(name);
                    
            }           
           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox myNewForm = new AboutBox();
            myNewForm.Show();

            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventLog.WriteEntry("Exiting User Sate Migration GUI");
            System.Environment.Exit(0);
        }

        private void Options_button_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options myNewForm = new Options();
            myNewForm.Show();
        }

        
        private void Migrate_button_Click(object sender, EventArgs e)
        {
            
            int selected = Users_local_checkedListBox.SelectedIndex;                             
            foreach (var itemChecked in Users_local_checkedListBox.CheckedItems)
            {
                
                if (selected != -1)
                {
                    string val = Users_local_checkedListBox.Items[selected].ToString();
                    User_listBox.Items.Add(val);
                }
                else
                {
                    
                    MessageBox.Show("No Migration User selected","Error in selection",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                    

                }
            
                }
                
            }
          

        }
    }

