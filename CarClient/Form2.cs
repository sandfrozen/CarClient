using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarClient
{
    public partial class Form2 : Form
    {
        private CarWS.ClientInterfaceClient service;
        private CarWS.customer customer;
        private CarWS.reservation[] reservations;
        private CarWS.reservation currentReservation = null;
        private CarWS.car[] cars;

        public Form2(int id)
        {
            InitializeComponent();
            service = new CarWS.ClientInterfaceClient();
            customer = service.getCustomer(id);
            cars = service.getCars();

            this.customerName.Text = UppercaseFirst(customer.name) + " " + UppercaseFirst(customer.surname);
            this.customerMail.Text = customer.mail;

            loadReservations();
            loadCars();

            dateTimePicker1.Value = DateTime.Today.AddDays(1);
            dateTimePicker3.Value = DateTime.Today.AddDays(1);
        }

        private void loadReservations()
        {
            listView1.Items.Clear();
            try
            {
                reservations = service.getCustomerReservations(customer.id);

                this.reservationsInfo.Text = "You have " + reservations.Length + " reservations:";

                foreach (CarWS.reservation r in reservations)
                {
                    CarWS.car c = service.getCar(r.car_id);
                    ListViewItem item = new ListViewItem(r.id.ToString());
                    double days = DaysBetween(r.from, r.to);
                    double cost = Math.Round((days * c.dayCost), 2);

                    item.SubItems.Add(r.car_id.ToString());
                    item.SubItems.Add(c.brand + " " + c.model);
                    item.SubItems.Add(days.ToString());
                    item.SubItems.Add(r.from.ToString());
                    item.SubItems.Add(r.to.ToString());
                    item.SubItems.Add(cost.ToString() + " zł");
                    listView1.Items.Add(item);
                }
            }
            catch
            {
                this.reservationsInfo.Text = "You have 0 reservation:";
            }
        }

        private void loadCars()
        {
            listView2.Items.Clear();
            foreach (CarWS.car c in cars)
            {
                ListViewItem item = new ListViewItem(c.id.ToString());

                item.SubItems.Add(c.brand);
                item.SubItems.Add(c.model);
                item.SubItems.Add(c.doors.ToString());
                item.SubItems.Add(c.fuelCap.ToString());
                item.SubItems.Add(c.fuelType);
                item.SubItems.Add(c.range.ToString());
                item.SubItems.Add(c.gearbox);
                item.SubItems.Add(c.gears.ToString());
                item.SubItems.Add(c.dayCost.ToString());

                listView2.Items.Add(item);
            }
        }

        private void loadReservationCarDetails()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                currentReservation = null;
                brand.Text = "-";
                model.Text = "-";
                doors.Text = "-";
                fuelCap.Text = "-";
                fuelType.Text = "-";
                range.Text = "-";
                gearbox.Text = "-";
                gears.Text = "-";
                dayCost.Text = "-";
                new Task(() => {
                    pictureBox2.Image = pictureBox2.InitialImage;
                }).Start();
                return;
            }
            
            int resId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            currentReservation = service.getReservation(resId);
            int carId = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
            CarWS.car car = service.getCar(carId);

            brand.Text = car.brand;
            model.Text = car.model;
            doors.Text = car.doors.ToString();
            fuelCap.Text = car.fuelCap.ToString();
            fuelType.Text = car.fuelType;
            range.Text = car.range.ToString();
            gearbox.Text = car.gearbox;
            gears.Text = car.gears.ToString();
            dayCost.Text = car.dayCost.ToString() + " zł";

            new Task(() => {
                var bytes = service.downloadCarImage(car.id);
                Image carImage = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
                pictureBox2.Image = carImage;
            }).Start();
            
        }

        private string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private double DaysBetween(String from, String to)
        {
            return ((DateTime.Parse(to) - DateTime.Parse(from)).TotalDays + 1);
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            loadReservationCarDetails();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (currentReservation == null) return;

            if (DateTime.Parse(currentReservation.to).CompareTo(DateTime.Today) < 0)
            {
                return;
            }

            CarWS.reservation tmp = currentReservation;
            tabControl1.SelectedIndex = 1;

            currentReservation = tmp;
            dateTimePicker1.Value = DateTime.Parse(currentReservation.from);
            dateTimePicker3.Value = DateTime.Parse(currentReservation.to);
            reservationLabel.Text = "You Are Editing Reservation: #" + currentReservation.id;

            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[0].Text == currentReservation.car_id.ToString())
                {
                    item.Selected = true;
                    item.BackColor = Color.LightSteelBlue;
                    break;
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (currentReservation != null)
            {
                if (DateTime.Parse(currentReservation.from).CompareTo(DateTime.Today) <= 0)
                {
                    return;
                }
            }
            int resId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            service.removeReservation(resId);
            loadReservations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadReservations();
            loadReservationCarDetails();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                listView1.SelectedItems.Clear();
                currentReservation = null;
            }
            else
            {
                loadAsNewRes();
            }
        }

        private void buttonNewRes_Click(object sender, EventArgs e)
        {
            loadAsNewRes();
        }

        private void loadAsNewRes()
        {
            currentReservation = null;
            reservationLabel.Text = "New Reservation:";
            loadCars();
            dateTimePicker1.Value = DateTime.Today.AddDays(1);
            dateTimePicker3.Value = DateTime.Today.AddDays(1);

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentReservation == null && dateTimePicker1.Value.CompareTo(DateTime.Today) < 0)
            {
                dateTimePicker1.Value = DateTime.Today;
            }
            if (dateTimePicker1.Value.CompareTo(dateTimePicker3.Value) == 1)
            {
                dateTimePicker3.Value = dateTimePicker1.Value;
            }
            if (dateTimePicker3.Value.CompareTo(DateTime.Today) < 0)
            {
                dateTimePicker3.Value = DateTime.Today;
            }
            if (listView2.SelectedItems.Count == 0) return;

            int carId = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            double days = DaysBetween(dateTimePicker1.Text, dateTimePicker3.Text);
            double cost = Double.Parse(listView2.SelectedItems[0].SubItems[9].Text) * days;
            summaryCost.Text = "Days: " + days + ".  Total Cost: " + Math.Round(cost, 2) + " zł";

            new Task(() => {  
                var bytes = service.downloadCarImage(carId);
                Image carImage = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
                pictureBox3.Image = carImage;
            }).Start();
        }

        private void buttonSaveRes_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) return;

            if (currentReservation != null)
            {
                int carId = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
                string from = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string to = dateTimePicker3.Value.ToString("yyyy-MM-dd");
                try
                {
                    if (service.editReservation(currentReservation.id, carId, customer.id, from, to))
                    {
                        MessageBox.Show("Rezerwacja #" + currentReservation.id + " została zmieniona.");
                    }
                    else
                    {
                        MessageBox.Show("Rezerwacja #" + currentReservation.id + " nie została zmieniona, bo..");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd: " + ex.Message + "\n" + "Zmień datę rezerwacji.");
                    return;
                }
            }
            else
            {
                int carId = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
                string from = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string to = dateTimePicker3.Value.ToString("yyyy-MM-dd");
                try
                {
                    if (service.newReservation(carId, customer.id, from, to))
                    {
                        int resId = service.getCustomerReservations(customer.id).Last().id;
                        MessageBox.Show("Samochód został zarezerwowany. Numer rezerwacji: #" + resId);
                    }
                    else
                    {
                        MessageBox.Show("Samochód został zarezerwowany, bo..");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd: " + ex.Message + "\n" + "Zmień datę rezerwacji.");
                    return;
                }
            }

            loadAsNewRes();
            tabControl1.SelectedIndex = 0;
            loadReservations();
        }

        private void reloadCars_Click(object sender, EventArgs e)
        {
            loadCars();
        }

        private void buttonGoToNewRes_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            loadAsNewRes();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
