using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KitProjects.Tests
{
    public class FileInfoTests
    {
        [Fact]
        public void File_info_name_is_a_file_name_with_extension()
        {
            var fileInfo = new FileInfo(@"C:\Users\admin\Pictures\Хронология Прослушиваний\01.png");

            var result = fileInfo.Name;

            result.Should().Be("01.png");
        }

        [Fact]
        public void File_info_extension_includes_a_dot()
        {
            var fileInfo = new FileInfo(@"C:\Users\admin\Pictures\Хронология Прослушиваний\01.png");

            var result = fileInfo.Extension;

            result.Should().Be(".png");
        }
    }
}
