using Dao;
using System;
using System.Windows.Forms;

namespace Users_Rallye
{
    public partial class users_Connection : Form
    {
        public users_Connection()
        {
            InitializeComponent();
            DaoConnectionSingleton.SetStringConnection("root", "siojjr", "172.16.20.51", "rallyeLecturembrd");
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            FConnexion usersInterface = new FConnexion();
            usersInterface.Show();
        }
    }
}
