using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Volo.Abp.DependencyInjection;

namespace Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 图片生成提供实现
    /// </summary>
    public class VerifyPictureProvider : IVerifyPictureProvider, ITransientDependency
    {
        /// <summary>
        /// 随机颜色库
        /// </summary>
        private readonly Brush[] _colorList = { Brushes.Black, Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.Orange, Brushes.Brown, Brushes.White, Brushes.DarkBlue };

        /// <summary>
        /// 随机字体大小库
        /// </summary>
        private readonly int[] _fontSizeList = { 10, 11, 12, 13, 14, 15, 16, 17, 18 };

        /// <summary>
        /// 随机字体库
        /// </summary>
        private readonly string[] _typeFace = "DejaVu Sans,Bradley Hand ITC".Split(",");

        /// <summary>
        /// 创建验证图片
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public async Task<byte[]> GenerateAsync(string input)
        {
            return await Task.Run(() =>
            {
                Random rnd = new Random();// 随机数对象
                Image image = new Bitmap(120, 40);// 创建图像区域
                Graphics graph = Graphics.FromImage(image);
                graph.Clear(Color.Gainsboro);

                var interferenceCount = rnd.Next(10,20);
                // 画噪线 
                for (int i = 0; i < interferenceCount; i++)
                {
                    Brush pencolor = _colorList[rnd.Next(_colorList.Length)]; // 生成随机颜色
                    Pen pen = new Pen(pencolor);
                    int x1 = rnd.Next(120);
                    int y1 = rnd.Next(40);
                    int x2 = rnd.Next(120);
                    int y2 = rnd.Next(40);

                    graph.DrawLines(pen, new Point[] { new Point(x1, y1), new Point(x2, y2) });
                }

                // 画验证码字符串 
                for (int i = 0; i < input.Length; i++)
                {
                    string fnt = _typeFace[rnd.Next(_typeFace.Length)];// 生成随机字体
                    Font fonts = new Font(fnt, _fontSizeList[rnd.Next(_fontSizeList.Length)]);// 生成随机字体大小
                    Brush colors = _colorList[rnd.Next(_colorList.Length)];// 生成随机颜色
                    // graph.DrawString(check[i], ft, new SolidBrush(clr), (float)i * 18, (float)0);
                    graph.DrawString(input[i].ToString(), fonts, colors, new PointF((float)i * 20, (float)0));// 写入字符
                }
                MemoryStream ms = new MemoryStream();
                try
                {
                    image.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    graph.Dispose();
                }

            });
        }

        /// <summary>
        /// 获取指定数量的随机字母和数字组合
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string CreateCode(int num)
        {
            string AllCode = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] CodeArray = AllCode.Split(',');
            string ReturnCode = "";
            Random rand = new Random();
            for (int i = 0; i < num; i++)
            {
                int r = rand.Next(60);
                ReturnCode += CodeArray[r];
            }
            return ReturnCode;
        }
    }
}
