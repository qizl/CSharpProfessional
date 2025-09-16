using System.ComponentModel;
using System.Globalization;

namespace CSharpProfessional.Core.Tests.CSharp14
{
    [TestClass]
    public class TypeConvert
    {
        /// <summary>
        /// 将字符串转换为目标类型
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="value">要转换的字符串值</param>
        /// <returns>转换后的值</returns>
        /// <exception cref="NotSupportedException">当不支持转换时抛出</exception>
        /// <exception cref="FormatException">当格式不正确时抛出</exception>
        public static T? ConvertTo<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }

            Type targetType = typeof(T);
            TypeConverter converter = TypeDescriptor.GetConverter(targetType);

            if (converter != null && converter.CanConvertFrom(typeof(string)))
            {
                try
                {
                    return (T?)converter.ConvertFromInvariantString(value);
                }
                catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
                {
                    throw new FormatException($"无法将字符串 '{value}' 转换为类型 {targetType.Name}", ex);
                }
            }

            throw new NotSupportedException($"不支持将字符串转换为类型 {targetType.Name}");
        }

        /// <summary>
        /// 尝试将字符串转换为目标类型
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="value">要转换的字符串值</param>
        /// <param name="result">转换后的值</param>
        /// <returns>转换是否成功</returns>
        public static bool TryConvertTo<T>(string value, out T? result)
        {
            try
            {
                result = ConvertTo<T>(value);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        [TestMethod]
        public void Run()
        {
            // 测试 Guid 转换
            var guidSrc = Guid.NewGuid();
            var guidStr = guidSrc.ToString();
            var guid = ConvertTo<Guid>(guidStr);
            Assert.AreEqual(guidSrc, guid);

            // 测试 DateTime 转换
            var dateTimeSrc = DateTime.Now;
            var dateTimeStr = dateTimeSrc.ToString("o"); // 使用往返格式
            var dateTime = ConvertTo<DateTime>(dateTimeStr);
            Assert.AreEqual(dateTimeSrc.ToString("o"), dateTime.ToString("o"));

            // 测试 double 转换
            var doubleSrc = 12.12d;
            var doubleStr = doubleSrc.ToString(CultureInfo.InvariantCulture);
            var @double = ConvertTo<double>(doubleStr);
            Assert.AreEqual(doubleSrc, @double);

            // 测试 int 转换
            var intSrc = 42;
            var intStr = intSrc.ToString(CultureInfo.InvariantCulture);
            var @int = ConvertTo<int>(intStr);
            Assert.AreEqual(intSrc, @int);

            // 测试 bool 转换
            var boolSrc = true;
            var boolStr = boolSrc.ToString();
            var @bool = ConvertTo<bool>(boolStr);
            Assert.AreEqual(boolSrc, @bool);

            // 测试 TryConvertTo 方法
            Assert.IsTrue(TryConvertTo<int>("123", out int result1));
            Assert.AreEqual(123, result1);

            Assert.IsFalse(TryConvertTo<int>("abc", out int result2));
            Assert.AreEqual(0, result2); // default value for int

            // 测试 null/empty 字符串
            Assert.AreEqual(default(Guid), ConvertTo<Guid>(null));
            Assert.AreEqual(default(DateTime), ConvertTo<DateTime>(""));

            // 测试异常情况
            try
            {
                ConvertTo<int>("abc");
                Assert.Fail("应抛出 FormatException");
            }
            catch (FormatException)
            {
                // 预期异常
            }

            try
            {
                ConvertTo<object>("test");
                Assert.Fail("应抛出 NotSupportedException");
            }
            catch (NotSupportedException)
            {
                // 预期异常
            }
        }
    }
}
