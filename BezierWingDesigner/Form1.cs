using Plot3D;
using System;
using System.Windows.Forms;
using static Plot3D.Editor3D;

namespace BezierWingDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DemoSurface(ePolygonMode.Fill);
        }

        private void editor3d1_Load(object sender, EventArgs e)
        {
            base.OnLoad(e);
            editor3d1.Clear();
            editor3d1.Recalculate(false);
            editor3d1.MouseControl = eMouseCtrl.L_Theta_L_Phi;
            editor3d1.Raster = eRaster.Off;
            editor3d1.BackColor = Color.FromArgb(50, 50, 50);
            editor3d1.TopLegendColor = Color.Empty;
        }

        private void DemoSurface(ePolygonMode e_Mode)
        {
            #region int s32_Values definition

            double[,] s32_Values = new double[,]
            {
                {1.5368, 1.5368, 1.5368, 1.5368, 1.5368, 1.5172, 1.4868, 1.4624, 1.4121, 1.3861, 1.3411, 1.2681, 1.1838, 1.1141, 1.0617, 0.9634, 0.9059, 0.9059, 0.9634, 1.0617, 1.1141, 1.1838, 1.2681, 1.3411, 1.3861, 1.4121, 1.4624, 1.4868, 1.5172, 1.5368, 1.5368, 1.5368, 1.5368, 1.5368},
                {1.5794, 1.5794, 1.5794, 1.5794, 1.5794, 1.5434, 1.4939, 1.4811, 1.4549, 1.4320, 1.4029, 1.3337, 1.2546, 1.1796, 1.1141, 1.0387, 0.9684, 0.9684, 1.0387, 1.1141, 1.1796, 1.2546, 1.3337, 1.4029, 1.4320, 1.4549, 1.4811, 1.4939, 1.5434, 1.5794, 1.5794, 1.5794, 1.5794, 1.5794},
                {1.6351, 1.6351, 1.6351, 1.6351, 1.6351, 1.5991, 1.5794, 1.5630, 1.5434, 1.5368, 1.5172, 1.4746, 1.3861, 1.3009, 1.2255, 1.1370, 1.0486, 1.0486, 1.1370, 1.2255, 1.3009, 1.3861, 1.4746, 1.5172, 1.5368, 1.5434, 1.5630, 1.5794, 1.5991, 1.6351, 1.6351, 1.6351, 1.6351, 1.6351},
                {1.7531, 1.7531, 1.7531, 1.7531, 1.7531, 1.7302, 1.7105, 1.6976, 1.6690, 1.6482, 1.6187, 1.5925, 1.5008, 1.4287, 1.3533, 1.2354, 1.1469, 1.1469, 1.2354, 1.3533, 1.4287, 1.5008, 1.5925, 1.6187, 1.6482, 1.6690, 1.6976, 1.7105, 1.7302, 1.7531, 1.7531, 1.7531, 1.7531, 1.7531},
                {1.9104, 1.9104, 1.9104, 1.9104, 1.9104, 1.8776, 1.8428, 1.8285, 1.8153, 1.7924, 1.7596, 1.7105, 1.6253, 1.5499, 1.4615, 1.3435, 1.2452, 1.2452, 1.3435, 1.4615, 1.5499, 1.6253, 1.7105, 1.7596, 1.7924, 1.8153, 1.8285, 1.8428, 1.8776, 1.9104, 1.9104, 1.9104, 1.9104, 1.9104},
                {2.0152, 2.0152, 2.0152, 2.0152, 2.0152, 1.9594, 1.9792, 1.9661, 1.9399, 1.9169, 1.8907, 1.8514, 1.7564, 1.6679, 1.5729, 1.4516, 1.3337, 1.3337, 1.4516, 1.5729, 1.6679, 1.7564, 1.8514, 1.8907, 1.9169, 1.9399, 1.9661, 1.9792, 1.9594, 2.0152, 2.0152, 2.0152, 2.0152, 2.0152},
                {2.1332, 2.1332, 2.1332, 2.1332, 2.1332, 2.0972, 2.0972, 2.0840, 2.0546, 2.0349, 2.0050, 1.9595, 1.8842, 1.7990, 1.7039, 1.5860, 1.4746, 1.4746, 1.5860, 1.7039, 1.7990, 1.8842, 1.9595, 2.0050, 2.0349, 2.0546, 2.0840, 2.0972, 2.0972, 2.1332, 2.1332, 2.1332, 2.1332, 2.1332},
                {2.2217, 2.2217, 2.2217, 2.2217, 2.2217, 2.1955, 2.1889, 2.1791, 2.1660, 2.1332, 2.1016, 2.0677, 2.0251, 1.9399, 1.8350, 1.7236, 1.6155, 1.6155, 1.7236, 1.8350, 1.9399, 2.0251, 2.0677, 2.1016, 2.1332, 2.1660, 2.1791, 2.1889, 2.1955, 2.2217, 2.2217, 2.2217, 2.2217, 2.2217},
                {2.3069, 2.3069, 2.3069, 2.3069, 2.3069, 2.2708, 2.2643, 2.2446, 2.2643, 2.2446, 2.2288, 2.1848, 2.1463, 2.0775, 1.9497, 1.8579, 1.7334, 1.7334, 1.8579, 1.9497, 2.0775, 2.1463, 2.1848, 2.2288, 2.2446, 2.2643, 2.2446, 2.2643, 2.2708, 2.3069, 2.3069, 2.3069, 2.3069, 2.3069},
                {2.3822, 2.3822, 2.3822, 2.3822, 2.3822, 2.3822, 2.3691, 2.3411, 2.3757, 2.3366, 2.3486, 2.3167, 2.2805, 2.2086, 2.0808, 1.9792, 1.8743, 1.8743, 1.9792, 2.0808, 2.2086, 2.2805, 2.3167, 2.3486, 2.3366, 2.3757, 2.3411, 2.3691, 2.3822, 2.3822, 2.3822, 2.3822, 2.3822, 2.3822},
                {2.4510, 2.4510, 2.4510, 2.4510, 2.4510, 2.4576, 2.4062, 2.4299, 2.4773, 2.4644, 2.4538, 2.4785, 2.4441, 2.3593, 2.2544, 2.1445, 2.0677, 2.0677, 2.1445, 2.2544, 2.3593, 2.4441, 2.4785, 2.4538, 2.4644, 2.4773, 2.4299, 2.4062, 2.4576, 2.4510, 2.4510, 2.4510, 2.4510, 2.4510},
                {2.5374, 2.5374, 2.5374, 2.5374, 2.5374, 2.5068, 2.4904, 2.5013, 2.5740, 2.5664, 2.5701, 2.6199, 2.6212, 2.5330, 2.4478, 2.3888, 2.3475, 2.3475, 2.3888, 2.4478, 2.5330, 2.6212, 2.6199, 2.5701, 2.5664, 2.5740, 2.5013, 2.4904, 2.5068, 2.5374, 2.5374, 2.5374, 2.5374, 2.5374},
                {2.6122, 2.6122, 2.6122, 2.6122, 2.6122, 2.5690, 2.5719, 2.5887, 2.6444, 2.6707, 2.6903, 2.7402, 2.7682, 2.7334, 2.6701, 2.7518, 2.7525, 2.7525, 2.7518, 2.6701, 2.7334, 2.7682, 2.7402, 2.6903, 2.6707, 2.6444, 2.5887, 2.5719, 2.5690, 2.6122, 2.6122, 2.6122, 2.6122, 2.6122},
                {2.5246, 2.5246, 2.5246, 2.6575, 2.6575, 2.6182, 2.6417, 2.6691, 2.7263, 2.7726, 2.8075, 2.8705, 2.9392, 2.9231, 2.9917, 3.0423, 3.0769, 3.0769, 3.0423, 2.9917, 2.9231, 2.9392, 2.8705, 2.8075, 2.7726, 2.7263, 2.6691, 2.6417, 2.6182, 2.6575, 2.6575, 2.5246, 2.5246, 2.5246},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.6935, 2.6706, 2.7263, 2.7623, 2.8377, 2.9065, 2.9852, 3.0540, 3.1246, 3.1469, 3.1916, 3.2178, 3.2672, 3.2672, 3.2178, 3.1916, 3.1469, 3.1246, 3.0540, 2.9852, 2.9065, 2.8377, 2.7623, 2.7263, 2.6706, 2.6935, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.7301, 2.7132, 2.7984, 2.8358, 2.9295, 3.0179, 3.0933, 3.1851, 3.2452, 3.2615, 3.2702, 3.3227, 3.3522, 3.3522, 3.3227, 3.2702, 3.2615, 3.2452, 3.1851, 3.0933, 3.0179, 2.9295, 2.8358, 2.7984, 2.7132, 2.7301, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.7421, 2.7689, 2.8377, 2.9000, 2.9852, 3.0802, 3.1621, 3.2342, 3.2588, 3.2935, 3.3161, 3.3587, 3.3980, 3.3980, 3.3587, 3.3161, 3.2935, 3.2588, 3.2342, 3.1621, 3.0802, 2.9852, 2.9000, 2.8377, 2.7689, 2.7421, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.7623, 2.8115, 2.9000, 2.9622, 3.0474, 3.1097, 3.1785, 3.2408, 3.2801, 3.3161, 3.3423, 3.3784, 3.4210, 3.4210, 3.3784, 3.3423, 3.3161, 3.2801, 3.2408, 3.1785, 3.1097, 3.0474, 2.9622, 2.9000, 2.8115, 2.7623, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.7755, 2.8312, 2.9360, 3.0048, 3.0802, 3.1162, 3.1785, 3.2408, 3.2768, 3.3161, 3.3653, 3.4079, 3.4472, 3.4472, 3.4079, 3.3653, 3.3161, 3.2768, 3.2408, 3.1785, 3.1162, 3.0802, 3.0048, 2.9360, 2.8312, 2.7755, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5167, 2.5167, 2.5167, 2.6492, 2.7886, 2.8606, 2.9622, 3.0333, 3.1228, 3.0999, 3.1719, 3.2342, 3.2768, 3.3227, 3.3718, 3.4144, 3.4603, 3.4603, 3.4144, 3.3718, 3.3227, 3.2768, 3.2342, 3.1719, 3.0999, 3.1228, 3.0333, 2.9622, 2.8606, 2.7886, 2.6492, 2.5167, 2.5167, 2.5167},
                {2.5167, 2.5167, 2.5167, 2.6492, 2.7886, 2.8803, 2.9983, 3.0671, 3.1293, 3.0933, 3.1490, 3.2047, 3.2539, 3.3096, 3.3653, 3.4210, 3.4669, 3.4669, 3.4210, 3.3653, 3.3096, 3.2539, 3.2047, 3.1490, 3.0933, 3.1293, 3.0671, 2.9983, 2.8803, 2.7886, 2.6492, 2.5167, 2.5167, 2.5167},
                {2.5167, 2.5167, 2.5167, 2.6492, 2.7984, 2.8934, 3.0264, 3.0867, 3.1457, 3.0867, 3.1228, 3.1851, 3.2342, 3.3096, 3.3718, 3.4210, 3.4767, 3.4767, 3.4210, 3.3718, 3.3096, 3.2342, 3.1851, 3.1228, 3.0867, 3.1457, 3.0867, 3.0264, 2.8934, 2.7984, 2.6492, 2.5167, 2.5167, 2.5167},
                {2.5167, 2.5167, 2.5167, 2.6492, 2.7984, 2.8934, 3.0264, 3.0867, 3.1457, 3.0867, 3.1228, 3.1851, 3.2342, 3.3096, 3.3718, 3.4210, 3.4767, 3.4767, 3.4210, 3.3718, 3.3096, 3.2342, 3.1851, 3.1228, 3.0867, 3.1457, 3.0867, 3.0264, 2.8934, 2.7984, 2.6492, 2.5167, 2.5167, 2.5167},
                {2.5167, 2.5167, 2.5167, 2.6492, 2.7886, 2.8803, 2.9983, 3.0671, 3.1293, 3.0933, 3.1490, 3.2047, 3.2539, 3.3096, 3.3653, 3.4210, 3.4669, 3.4669, 3.4210, 3.3653, 3.3096, 3.2539, 3.2047, 3.1490, 3.0933, 3.1293, 3.0671, 2.9983, 2.8803, 2.7886, 2.6492, 2.5167, 2.5167, 2.5167},
                {2.5167, 2.5167, 2.5167, 2.6492, 2.7886, 2.8606, 2.9622, 3.0333, 3.1228, 3.0999, 3.1719, 3.2342, 3.2768, 3.3227, 3.3718, 3.4144, 3.4603, 3.4603, 3.4144, 3.3718, 3.3227, 3.2768, 3.2342, 3.1719, 3.0999, 3.1228, 3.0333, 2.9622, 2.8606, 2.7886, 2.6492, 2.5167, 2.5167, 2.5167},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.7755, 2.8312, 2.9360, 3.0048, 3.0802, 3.1162, 3.1785, 3.2408, 3.2768, 3.3161, 3.3653, 3.4079, 3.4472, 3.4472, 3.4079, 3.3653, 3.3161, 3.2768, 3.2408, 3.1785, 3.1162, 3.0802, 3.0048, 2.9360, 2.8312, 2.7755, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.7623, 2.8115, 2.9000, 2.9622, 3.0474, 3.1097, 3.1785, 3.2408, 3.2801, 3.3161, 3.3423, 3.3784, 3.4210, 3.4210, 3.3784, 3.3423, 3.3161, 3.2801, 3.2408, 3.1785, 3.1097, 3.0474, 2.9622, 2.9000, 2.8115, 2.7623, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.7421, 2.7689, 2.8377, 2.9000, 2.9852, 3.0802, 3.1621, 3.2342, 3.2588, 3.2935, 3.3161, 3.3587, 3.3980, 3.3980, 3.3587, 3.3161, 3.2935, 3.2588, 3.2342, 3.1621, 3.0802, 2.9852, 2.9000, 2.8377, 2.7689, 2.7421, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.7301, 2.7132, 2.7984, 2.8358, 2.9295, 3.0179, 3.0933, 3.1851, 3.2452, 3.2615, 3.2702, 3.3227, 3.3522, 3.3522, 3.3227, 3.2702, 3.2615, 3.2452, 3.1851, 3.0933, 3.0179, 2.9295, 2.8358, 2.7984, 2.7132, 2.7301, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5049, 2.5049, 2.5049, 2.6367, 2.6935, 2.6706, 2.7263, 2.7623, 2.8377, 2.9065, 2.9852, 3.0540, 3.1246, 3.1469, 3.1916, 3.2178, 3.2672, 3.2672, 3.2178, 3.1916, 3.1469, 3.1246, 3.0540, 2.9852, 2.9065, 2.8377, 2.7623, 2.7263, 2.6706, 2.6935, 2.6367, 2.5049, 2.5049, 2.5049},
                {2.5246, 2.5246, 2.5246, 2.6575, 2.6575, 2.6182, 2.6417, 2.6691, 2.7263, 2.7726, 2.8075, 2.8705, 2.9392, 2.9231, 2.9917, 3.0423, 3.0769, 3.0769, 3.0423, 2.9917, 2.9231, 2.9392, 2.8705, 2.8075, 2.7726, 2.7263, 2.6691, 2.6417, 2.6182, 2.6575, 2.6575, 2.5246, 2.5246, 2.5246},
                {2.6122, 2.6122, 2.6122, 2.6122, 2.6122, 2.5690, 2.5719, 2.5887, 2.6444, 2.6707, 2.6903, 2.7402, 2.7682, 2.7334, 2.6701, 2.7518, 2.7525, 2.7525, 2.7518, 2.6701, 2.7334, 2.7682, 2.7402, 2.6903, 2.6707, 2.6444, 2.5887, 2.5719, 2.5690, 2.6122, 2.6122, 2.6122, 2.6122, 2.6122},
                {2.5374, 2.5374, 2.5374, 2.5374, 2.5374, 2.5068, 2.4904, 2.5013, 2.5740, 2.5664, 2.5701, 2.6199, 2.6212, 2.5330, 2.4478, 2.3888, 2.3475, 2.3475, 2.3888, 2.4478, 2.5330, 2.6212, 2.6199, 2.5701, 2.5664, 2.5740, 2.5013, 2.4904, 2.5068, 2.5374, 2.5374, 2.5374, 2.5374, 2.5374},
                {2.4510, 2.4510, 2.4510, 2.4510, 2.4510, 2.4576, 2.4062, 2.4299, 2.4773, 2.4644, 2.4538, 2.4785, 2.4441, 2.3593, 2.2544, 2.1445, 2.0677, 2.0677, 2.1445, 2.2544, 2.3593, 2.4441, 2.4785, 2.4538, 2.4644, 2.4773, 2.4299, 2.4062, 2.4576, 2.4510, 2.4510, 2.4510, 2.4510, 2.4510},
                {2.3822, 2.3822, 2.3822, 2.3822, 2.3822, 2.3822, 2.3691, 2.3411, 2.3757, 2.3366, 2.3486, 2.3167, 2.2805, 2.2086, 2.0808, 1.9792, 1.8743, 1.8743, 1.9792, 2.0808, 2.2086, 2.2805, 2.3167, 2.3486, 2.3366, 2.3757, 2.3411, 2.3691, 2.3822, 2.3822, 2.3822, 2.3822, 2.3822, 2.3822},
                {2.3069, 2.3069, 2.3069, 2.3069, 2.3069, 2.2708, 2.2643, 2.2446, 2.2643, 2.2446, 2.2288, 2.1848, 2.1463, 2.0775, 1.9497, 1.8579, 1.7334, 1.7334, 1.8579, 1.9497, 2.0775, 2.1463, 2.1848, 2.2288, 2.2446, 2.2643, 2.2446, 2.2643, 2.2708, 2.3069, 2.3069, 2.3069, 2.3069, 2.3069},
                {2.2217, 2.2217, 2.2217, 2.2217, 2.2217, 2.1955, 2.1889, 2.1791, 2.1660, 2.1332, 2.1016, 2.0677, 2.0251, 1.9399, 1.8350, 1.7236, 1.6155, 1.6155, 1.7236, 1.8350, 1.9399, 2.0251, 2.0677, 2.1016, 2.1332, 2.1660, 2.1791, 2.1889, 2.1955, 2.2217, 2.2217, 2.2217, 2.2217, 2.2217},
                {2.1332, 2.1332, 2.1332, 2.1332, 2.1332, 2.0972, 2.0972, 2.0840, 2.0546, 2.0349, 2.0050, 1.9595, 1.8842, 1.7990, 1.7039, 1.5860, 1.4746, 1.4746, 1.5860, 1.7039, 1.7990, 1.8842, 1.9595, 2.0050, 2.0349, 2.0546, 2.0840, 2.0972, 2.0972, 2.1332, 2.1332, 2.1332, 2.1332, 2.1332},
                {2.0152, 2.0152, 2.0152, 2.0152, 2.0152, 1.9594, 1.9792, 1.9661, 1.9399, 1.9169, 1.8907, 1.8514, 1.7564, 1.6679, 1.5729, 1.4516, 1.3337, 1.3337, 1.4516, 1.5729, 1.6679, 1.7564, 1.8514, 1.8907, 1.9169, 1.9399, 1.9661, 1.9792, 1.9594, 2.0152, 2.0152, 2.0152, 2.0152, 2.0152},
                {1.9104, 1.9104, 1.9104, 1.9104, 1.9104, 1.8776, 1.8428, 1.8285, 1.8153, 1.7924, 1.7596, 1.7105, 1.6253, 1.5499, 1.4615, 1.3435, 1.2452, 1.2452, 1.3435, 1.4615, 1.5499, 1.6253, 1.7105, 1.7596, 1.7924, 1.8153, 1.8285, 1.8428, 1.8776, 1.9104, 1.9104, 1.9104, 1.9104, 1.9104},
                {1.7531, 1.7531, 1.7531, 1.7531, 1.7531, 1.7302, 1.7105, 1.6976, 1.6690, 1.6482, 1.6187, 1.5925, 1.5008, 1.4287, 1.3533, 1.2354, 1.1469, 1.1469, 1.2354, 1.3533, 1.4287, 1.5008, 1.5925, 1.6187, 1.6482, 1.6690, 1.6976, 1.7105, 1.7302, 1.7531, 1.7531, 1.7531, 1.7531, 1.7531},
                {1.6351, 1.6351, 1.6351, 1.6351, 1.6351, 1.5991, 1.5794, 1.5630, 1.5434, 1.5368, 1.5172, 1.4746, 1.3861, 1.3009, 1.2255, 1.1370, 1.0486, 1.0486, 1.1370, 1.2255, 1.3009, 1.3861, 1.4746, 1.5172, 1.5368, 1.5434, 1.5630, 1.5794, 1.5991, 1.6351, 1.6351, 1.6351, 1.6351, 1.6351},
                {1.5794, 1.5794, 1.5794, 1.5794, 1.5794, 1.5434, 1.4939, 1.4811, 1.4549, 1.4320, 1.4029, 1.3337, 1.2546, 1.1796, 1.1141, 1.0387, 0.9684, 0.9684, 1.0387, 1.1141, 1.1796, 1.2546, 1.3337, 1.4029, 1.4320, 1.4549, 1.4811, 1.4939, 1.5434, 1.5794, 1.5794, 1.5794, 1.5794, 1.5794},
                {1.5368, 1.5368, 1.5368, 1.5368, 1.5368, 1.5172, 1.4868, 1.4624, 1.4121, 1.3861, 1.3411, 1.2681, 1.1838, 1.1141, 1.0617, 0.9634, 0.9059, 0.9059, 0.9634, 1.0617, 1.1141, 1.1838, 1.2681, 1.3411, 1.3861, 1.4121, 1.4624, 1.4868, 1.5172, 1.5368, 1.5368, 1.5368, 1.5368, 1.5368},
            };

            #endregion

            int s32_Cols = s32_Values.GetLength(0);
            int s32_Rows = s32_Values.GetLength(1);

            // In Line mode the pen is used to draw the polygon border lines. The color is assigned from the ColorScheme.
            // In Fill mode the pen is used to draw the thin separator lines (always 1 pixel, black)
            Pen i_Pen = (e_Mode == ePolygonMode.Lines) ? new Pen(Color.Yellow, 2) : Pens.Transparent;

            cColorScheme i_Scheme = new cColorScheme(Plot3D.Editor3D.eColorScheme.Hot);
            cSurfaceData i_Data = new cSurfaceData(e_Mode, s32_Cols, s32_Rows, i_Pen, i_Scheme);
            cSurfaceData i_Data2 = new cSurfaceData(e_Mode, s32_Cols, s32_Rows, i_Pen, i_Scheme);

            for (int C = 0; C < i_Data.Cols; C++)
            {
                for (int R = 0; R < i_Data.Rows; R++)
                {
                    double s32_RawValue = s32_Values[C, R];

                    double d_X = C;
                    double d_Y = R;
                    double d_Z = (s32_RawValue - 0.9059) * 5;

                    String s_Tooltip = String.Format("Col = {0}\nRow = {1}\nRaw Value = {2}", C, R, s32_RawValue);
                    cPoint3D i_Point = new cPoint3D(d_X, d_Y, d_Z, s_Tooltip, s32_RawValue);
                    cPoint3D i_Point2 = new cPoint3D(d_X, d_Y, -d_Z, s_Tooltip, s32_RawValue);

                    i_Data.SetPointAt(C, R, i_Point);
                    i_Data2.SetPointAt(C, R, i_Point2);
                }
            }

            editor3d1.Clear();
            editor3d1.Normalize = eNormalize.MaintainXYZ;
            editor3d1.AddRenderData(i_Data); editor3d1.AddRenderData(i_Data2);

            //editor3d1.Selection.Callback = OnSelectEvent;
            editor3d1.Selection.HighlightColor = Color.FromArgb(100, 100, 100);
            editor3d1.Selection.MultiSelect = true;
            //editor3d1.Selection.Enabled = true;
            editor3d1.Recalculate(true);
            editor3d1.TooltipMode = eTooltip.Off;

            // Single point selection works only in Fill mode
            //if (e_Mode == ePolygonMode.Lines)
            //checkPointSelection.Enabled = false;

            // FIRST: Adjust Selection.SinglePoints which will remove all current selections
            //checkPointSelection.Checked = (e_Mode == ePolygonMode.Lines);

            // AFTER: Pre-select one polygon
            //cPolygon3D i_Polygon = i_Data.GetPolygonAt(10, 5);

            //if (editor3D.Selection.SinglePoints) // Select the 4 corner points
            //{
            //    foreach (cPoint3D i_Point in i_Polygon.Points)
            //    {
            //        i_Point.Selected = true;
            //    }
            //}
            //else // Select the polygon itself
            //{
            //    i_Polygon.Selected = true;
            //}
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            editor3d1.Height = this.ClientSize.Height /*- editor3d1.Top * 2*/;
            editor3d1.Width = this.ClientSize.Width /*- editor3d1.Left * 2*/;
        }
    }
}