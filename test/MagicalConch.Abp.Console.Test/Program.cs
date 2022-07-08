// See https://aka.ms/new-console-template for more information


using MaigcalConch.Abp.Captcha.Slider;

Console.WriteLine("请输入滑动最小运动速度阈值（1-1000）：");
var data1 = Console.ReadLine();
Console.WriteLine("请输入滑动最大运动速度阈值（1-1000）：");
var data2 = Console.ReadLine();

var provider = new SliderVerificationProvider(int.Parse(data2), int.Parse(data1));

while (true)
{
    Console.WriteLine("请输入运动Y轴坐标数组(1,2,3...)：");
    var data = Console.ReadLine();
    var result = await provider.VerificationAsync(new ValidationModel<int[]>(data.Split(",").Select(c=> int.Parse(c)).ToArray(),
    new SliderActionModel("127.0.0.1")));
    Console.WriteLine(result);
}
