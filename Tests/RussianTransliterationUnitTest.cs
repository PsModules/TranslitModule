using System.Management.Automation;
using System.Reflection;
using TranslitModule;
using Xunit;

namespace Tests
{
    public class RussianTransliterationUnitTest
    {
        [Fact]
        public void ShouldTranslitRussianPhrase()
        {
            // Arrange.
            var phrase = "Во поле берёза стояла, " +
                         "Во поле кудрявая стояла. " +
                         "Люли люли, стояла, " +
                         "Люли люли, стояла." ;
            var expected= "Vo pole beryoza stoyala, " +
                          "Vo pole kudryavaya stoyala. " +
                          "Lyuli lyuli, stoyala, " +
                          "Lyuli lyuli, stoyala.";

            var cmdlet = new CyrillicToLatinCmdletCommand()
            {
                Text =  phrase,
                Lng = "ru"
            };

            // Act.

            var result = cmdlet.Invoke().GetEnumerator();

            Assert.True(result.MoveNext());
            Assert.True(result.Current is string);
            Assert.Equal(expected, result.Current);
           
            
        }
        
        [Fact]
        public void ShouldTranslitLatinPhraseToRussian()
        {
            // Arrange.
            var phrase = "Ya zh pojdu pohulyayu, " +
                         "Beluyu beryozu zalomayu." +
                         "Lyuli lyuli, zalomayu, " +
                         "Lyuli lyuli, zalomayu.";
                
            var expected= "Я ж пойду погуляю, " +
                          "Белую берёзу заломаю." +
                          "Люли люли, заломаю, " +
                          "Люли люли, заломаю.";

            var cmdlet = new LatinToCyrillicCmdletCommand()
            {
                Text =  phrase,
                Lng = "ru"
            };
            
           
            // Act.
            var result = cmdlet.Invoke().GetEnumerator();
            
            Assert.True(result.MoveNext());
            Assert.True(result.Current is string);
            Assert.Equal(expected, result.Current);

        }
    }
    
}