using System;
using System.IO;
using System.Reflection;

namespace Runewords.Helpers
{
	public static class FileSystemHelper
	{
        public static string AssemblyDirectory
        {
            get
            {
#pragma warning disable SYSLIB0012 // Type or member is obsolete
				var uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase!);
#pragma warning restore SYSLIB0012 // Type or member is obsolete

				return Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path))!;
            }
        }
    }
}
