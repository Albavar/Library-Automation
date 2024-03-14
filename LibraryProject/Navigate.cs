using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryProject
{
    public partial class Navigate : Form
    {
        public Navigate()
        {
            InitializeComponent();
        }

        private void Navigate_Load(object sender, EventArgs e)
        {

        }

        private void Members_Click(object sender, EventArgs e)
        {
                Members members = new Members();
                members.Show();
        }

        private void Publishers_Click(object sender, EventArgs e)
        {
             Publishers publishers = new Publishers();
             publishers.Show();
        }

        private void Authors_Click(object sender, EventArgs e)
        {
            Authors authors = new Authors();
            authors.Show();
        }

        private void Shelfs_Click(object sender, EventArgs e)
        {
            Shelfs shelfs = new Shelfs();
            shelfs.Show();
        }

        private void Genres_Click(object sender, EventArgs e)
        {
            Genres genres = new Genres();
            genres.Show();
        }

        private void Staff_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
        }

        private void Books_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
        }

    }
}
