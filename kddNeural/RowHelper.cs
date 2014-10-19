using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace kddNeural
{
    public enum GenericConnectionType
    {
        normal, suspicious
    };

    public enum MiddleSpecificConnectionType
    {
        normal, probe, u2r, r2l, dos
    };

    public enum SpecificConnectionType
    {
        normal, back, buffer_overflow,
        ftp_write, guess_passwd, imap,
        ipsweep, land, loadmodule,
        multihop, neptune, nmap, perl, phf,
        pod, portsweep, rootkit, satan, smurf,
        spy, teardrop, warezclient, warezmaster
    };
    public enum Protocol
    {
        http, smtp, finger, domain_u, auth, telnet,
        ftp, eco_i, ntp_u, ecr_i, other
    };
    public static class RowHelper
    {
        private static readonly Dictionary<SpecificConnectionType, MiddleSpecificConnectionType> dict =
            new Dictionary<SpecificConnectionType, MiddleSpecificConnectionType>()
            {
                {SpecificConnectionType.back,            MiddleSpecificConnectionType.dos},
                {SpecificConnectionType.buffer_overflow, MiddleSpecificConnectionType.u2r},
                {SpecificConnectionType.ftp_write,       MiddleSpecificConnectionType.r2l},
                {SpecificConnectionType.guess_passwd,    MiddleSpecificConnectionType.r2l},
                {SpecificConnectionType.imap,            MiddleSpecificConnectionType.r2l},
                {SpecificConnectionType.ipsweep,         MiddleSpecificConnectionType.probe},
                {SpecificConnectionType.land,            MiddleSpecificConnectionType.dos},
                {SpecificConnectionType.loadmodule,      MiddleSpecificConnectionType.u2r},
                {SpecificConnectionType.multihop,        MiddleSpecificConnectionType.r2l},
                {SpecificConnectionType.neptune,         MiddleSpecificConnectionType.dos},
                {SpecificConnectionType.nmap,            MiddleSpecificConnectionType.probe},
                {SpecificConnectionType.perl,            MiddleSpecificConnectionType.u2r},
                {SpecificConnectionType.phf,             MiddleSpecificConnectionType.r2l},
                {SpecificConnectionType.pod,             MiddleSpecificConnectionType.dos},
                {SpecificConnectionType.portsweep,       MiddleSpecificConnectionType.probe},
                {SpecificConnectionType.rootkit,         MiddleSpecificConnectionType.u2r},
                {SpecificConnectionType.satan,           MiddleSpecificConnectionType.probe},
                {SpecificConnectionType.smurf,           MiddleSpecificConnectionType.dos},
                {SpecificConnectionType.spy,             MiddleSpecificConnectionType.r2l},
                {SpecificConnectionType.teardrop,        MiddleSpecificConnectionType.dos},
                {SpecificConnectionType.warezclient,     MiddleSpecificConnectionType.r2l},
                {SpecificConnectionType.warezmaster,     MiddleSpecificConnectionType.r2l}
            };
        public static T GetEnumFromString<T>(string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }

        public static GenericConnectionType GetGenericConnectionType(string s)
        {
            if (s.Contains("normal")) return GenericConnectionType.normal;
            return GenericConnectionType.suspicious;
        }

        public static MiddleSpecificConnectionType GetMiddleSpecificConnectionType(string s)
        {
            var specific = GetEnumFromString<SpecificConnectionType>(s);

            return dict[specific];
        }

    }
}
