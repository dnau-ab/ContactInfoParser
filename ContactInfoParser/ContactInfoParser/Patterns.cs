using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoParser
{
    static class Patterns
    {
        // checks for first name, mi, last name (possibly hyphenated)
        public const String name = @"[A-Z][A-Za-z]+[ \t]+([A-Z].?[ \t]+)?([A-Z][A-Za-z]+(-[A-Za-z]+)?)";

        // supports +# (###) ###-#### with or without the country code, parens, hyphen, or spaces
        public const String phone = @"([+]\d+[ \t]*.?)?(\d\d\d).?[ \t]*(\d\d\d).?[ \t]*(\d\d\d\d)";

        // emails may have other top level domains; here I use some common ones
        public const String email = @"[a-zA-Z]([a-zA-Z0-9].?)*[a-zA-Z0-9]@([a-zA-Z0-9].?[a-zA-Z0-9])+.(com|net|edu|org|gov)";

    }
}
