using MaigcalConch.Abp.Captcha.Samples;
using Xunit;

namespace MaigcalConch.Abp.Captcha.MongoDB.Samples
{
    [Collection(MongoTestCollection.Name)]
    public class SampleRepository_Tests : SampleRepository_Tests<CaptchaMongoDbTestModule>
    {
        /* Don't write custom repository tests here, instead write to
         * the base class.
         * One exception can be some specific tests related to MongoDB.
         */
    }
}
