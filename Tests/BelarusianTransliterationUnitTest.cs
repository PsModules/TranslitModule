using System.Management.Automation;
using System.Reflection;
using TranslitModule;
using Xunit;

namespace Tests
{
    public class BelarusianTransliterationUnitTest
    {
        [Fact]
        public void ShouldTranslitBelarusianPhrase()
        {
            // Arrange.
            var phrase = "Малюся я небу, зямлі і прастору." +
                         "Магутнаму Богу - Ўсясвету малюсь." ;
            var expected= "Malyusya ya nebu, zyamlі і prastoru.Mahutnamu Bohu - U`syasvetu malyus`.";

            var cmdlet = new CyrillicToLatinCmdletCommand()
            {
                Text =  phrase,
                Lng = "by"
            };

            // Act.

            var result = cmdlet.Invoke().GetEnumerator();

            
            Assert.True(result.MoveNext());
            Assert.True(result.Current is string);
            Assert.Equal(expected, result.Current);
           
            
        }
        
        [Fact]
        public void ShouldTranslitLatinPhraseToBelarusian()
        {
            // Arrange.
            var phrase = "Va u`syakaj pry`hodze, va u`syakuyu poruZa rodny` narod Belarusі.";
                
            var expected= "Ва ўсякай прыгодзе, ва ўсякую пору" +
                         "За родны народ Беларусі.";

            var cmdlet = new LatinToCyrillicCmdletCommand()
            {
                Text =  phrase,
                Lng = "by"
            };
            // Act.

            var result = cmdlet.Invoke().GetEnumerator();
            
            Assert.True(result.MoveNext());
            Assert.True(result.Current is string);
            Assert.Equal(expected, result.Current);

        }
    }
    
}