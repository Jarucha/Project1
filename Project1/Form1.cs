using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        int temp = 0; //กำหนดตัวแปร
        double sum = 0;
        string num;
        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3; //จำนวนคอลัมน์ใส่ใน dataGridView1
            dataGridView1.Columns[0].Name = "รายวิชา";
            dataGridView1.Columns[1].Name = "หน่วยกิต";
            dataGridView1.Columns[2].Name = "เกรด";

            string[] row = new string[] { "000 101", "3" }; //กำหนดรายวิชาที่เรียนใส่ใน dataGridView1
            dataGridView1.Rows.Add(row);
            row = new string[] { "000 174", "3" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "935 101", "3" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "935 102", "3" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "935 103", "3" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "935 104", "3" }; 
            dataGridView1.Rows.Add(row);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try //กัน error
            {

                int credit; //ตัวแปรที่สร้างมาไว้สำหรับเก็บหน่วยกิตแต่ละตัว
                int countRow = dataGridView1.RowCount; //คือการนับจำนวนแถว แล้วเก็บไว้ใน countrow
                for (int i = 0; i < countRow - 1; i++) //สร้างลูปที่มีขนาดเล็กกว่าจำนวนบรรทัดทั้งหมด -1 เพราะว่าบรรทัดสุดท้ายไม่มีข้อมูล
                {

                    num = dataGridView1.Rows[i].Cells[1].Value.ToString(); //เอาหน่วยกิตแต่ละตัวเก็บไว้ใน num ข้อมูลแถวที่ i คอลัมที่ 1 แล้วแปลงเป็นสตริง ก่อนเก็บไว้ใน num
                    credit = int.Parse(num); //เอา num มาแปลงเป็น int แล้วเก็บไว้ใน credit
                    temp = temp + credit; //เอา temp ซึ่งตอนแรกไม่มีข้อมูล มาเก็บหน่วยกิตแต่ละบรรทัด แบบวนลูบ แล้วบวกเข้ากับอันเก่าเรื่อยๆ

                }

                int LA1 = 0; // กำหนดตัวแปรนี้คือเกรดเฉลี่ยที่ผ่าน คือ A B+ B C+ C D+ D 
                int LA2 = 0; //กำหนดตัวแปรนี้คือเกรดเฉลี่ยที่ไม่ผ่าน คือ F

                string ID = (textBox1.Text); //คำสั่งใส่ใน textBox1
                label19.Text = ("รหัสนักศึกษา : " + ID).ToString(); //คำสั่งโชว์ใน  label19
                string Name = (textBox2.Text); //คำสั่งใส่ใน textBox2
                label20.Text = ("ชื่อ - นามสกุล : " + Name).ToString();  //คำสั่งโชว์ใน  label20
                int countRow2 = dataGridView1.RowCount; //เหมือนอัน countrow อันแรก คือนับแถว นับอีกรอบ
                double[] DEE; //อาเรย์ของเกรด สร้างอาเรย์ สำหรับเก็บเกรดแต่ละตัวเมื่อนำไปวนลูป

                DEE = new double[countRow2]; //เป็นการกำหนดขนาดของด้านบน ให้อาเรย์ DEE มีขนาดเท่ากับ จำนวนบรรทัดที่นับได้ จากตัวแปร countRow2

                for (int i = 0; i < countRow - 1; i++) //การสร้างลูปโดยให้จำนวนที่วนลูปน้อยกว่าจำนวนบรรทัดอยู่ 1 คือ countRow - 1
                {
                    switch (dataGridView1.Rows[i].Cells[2].Value.ToString()) //ทำหน้าที่เช็คตัวแปร
                    {
                        case "A": DEE[i] = 4; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break; //ถ้ารับ A เข้ามา จะได้เป็น เกรด 4 กำหนดให้ LA1 เป็นหน่วยกิตที่ผ่านแล้ว
                        case "B+": DEE[i] = 3.5; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break; //ถ้ารับ B+เข้ามา จะได้เป็น เกรด 3.5 กำหนดให้ LA1 เป็นหน่วยกิตที่ผ่านแล้ว
                        case "B": DEE[i] = 3; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break; //ถ้ารับ B เข้ามา จะได้เป็น เกรด 3 กำหนดให้ LA1 เป็นหน่วยกิตที่ผ่านแล้ว
                        case "C+": DEE[i] = 2.5; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;//ถ้ารับ C+ เข้ามา จะได้เป็น เกรด 2.5 กำหนดให้ LA1 เป็นหน่วยกิตที่ผ่านแล้ว
                        case "C": DEE[i] = 2; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break; //ถ้ารับ C เข้ามา จะได้เป็น เกรด 2 กำหนดให้ LA1 เป็นหน่วยกิตที่ผ่านแล้ว
                        case "D+": DEE[i] = 1.5; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break; //ถ้ารับ D+ เข้ามา จะได้เป็น เกรด 1.5 กำหนดให้ LA1 เป็นหน่วยกิตที่ผ่านแล้ว
                        case "D": DEE[i] = 1; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break; //ถ้ารับ D เข้ามา  จะได้เป็น เกรด 1 กำหนดให้ LA1 เป็นหน่วยกิตที่ผ่านแล้ว
                        case "F": DEE[i] = 0; LA2 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break; //ถ้ารับเข้ามาเป็น F จะปรับเกรดเป็น 0 กำหนดให้ LA2 เป็นหน่วยกิตที่ไม่ผ่าน

                        case "a": DEE[i] = 4; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;
                        case "b+": DEE[i] = 3.5; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;
                        case "b": DEE[i] = 3; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;
                        case "c+": DEE[i] = 2.5; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;
                        case "c": DEE[i] = 2; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;
                        case "d+": DEE[i] = 1.5; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;
                        case "d": DEE[i] = 1; LA1 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;
                        case "f": DEE[i] = 0; LA2 += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); break;
                        default:
                            MessageBox.Show("ใส่ข้อมูลให้ถูกต้อง"); //ถ้าใส่ข้อมูลไม่ถูกจะเด้งขึ้นโชว์
                            break;
                    }
                    sum = sum + DEE[i] * int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()); //เอาเกรดคูณหน่วยกิต แล้วบวกกันแล้วรวมไว้ใน sum แล้วแปลงเป็นสตริง ก่อนเก็บไว้ใน sum
                }

                double sum1 = sum / temp; //ผลรวมของเกรคูนหน่วยกิตหารหน่วยกิตทั้งหมด
                label24.Text = Convert.ToString(sum1); // แสดงผลเกรดเฉลี่ย
                label25.Text = Convert.ToString(LA1); // แสดงหน่วยกิตที่ผ่านแล้ว
                label26.Text = Convert.ToString(LA2); // แสดงหน่วยกิตที่ไม่ผ่าน
                button1.Enabled = false;
            }

            catch { } //กัน error
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); //ปิดโปรแกรม
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show(); //สั่งเปิดฟอร์มใหม่
            this.Dispose(false); //ปิดฟอร์มเก่า
        }

       
    }
}
