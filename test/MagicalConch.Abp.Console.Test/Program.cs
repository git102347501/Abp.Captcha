// See https://aka.ms/new-console-template for more information


using MaigcalConch.Abp.Captcha.Slider;

var provider = new SliderVerificationProvider(80,230);

while (true)
{
    var data = Console.ReadLine();
    var result = await provider.VerificationAsync(new ValidationModel<int[]>(data.Split(",").Select(c=> int.Parse(c)).ToArray(),
    new SliderActionModel("127.0.0.1")));
    Console.WriteLine(result);
}
