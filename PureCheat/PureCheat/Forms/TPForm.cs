using System;
using UnityEngine;
using System.Data;
using System.Linq;
using System.Text;
using PureCheat.API;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PureCheat.Forms
{
    public partial class TPForm : Form
    {
        Point lastPoint;

        public TPForm()
        {
            InitializeComponent();
        }

        private void TPToObjectForm_Load(object sender, EventArgs e)
        {
            foreach (GameObject gameObject in PureUtils.GetAllObjectsInSceneTree())
                AllObjectSelectionBox.Items.Add(gameObject.transform.name);

            foreach (GameObject gameObject in PureUtils.GetAllGameObjects())
                ObjectSelectionBox.Items.Add(gameObject.transform.name);

            foreach (GameObject gameObject in PureUtils.GetAllPlayers())
                PlayerSelectionBox.Items.Add(gameObject.transform.name);

            ObjectSelectionBox.SelectedIndex = 0;
            PlayerSelectionBox.SelectedIndex = 0;
            AllObjectSelectionBox.SelectedIndex = 0;
        }

        private void TPToObjectForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void TPToObjectForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                lastPoint = new Point(e.X, e.Y);
        }

        private void TeleportButton_Click(object sender, EventArgs e)
        {
            PureUtils.GetLocalPlayer().transform.position = PureUtils.GetAllObjectsInSceneTree()[AllObjectSelectionBox.SelectedIndex].transform.position;
            Close();
        }

        private void TeleportToObjButton_Click(object sender, EventArgs e)
        {
            PureUtils.GetLocalPlayer().transform.position = PureUtils.GetAllGameObjects()[ObjectSelectionBox.SelectedIndex].transform.position;
            Close();
        }

        private void TeleportToPlayerButton_Click(object sender, EventArgs e)
        {
            PureUtils.GetLocalPlayer().transform.position = PureUtils.GetAllPlayers()[PlayerSelectionBox.SelectedIndex].transform.position;
            Close();
        }
    }
}
