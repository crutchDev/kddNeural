using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kddNeural.Logic
{
    //public enum Protocol
    //{
    //    http, smtp, finger, domain_u, auth, telnet,
    //    ftp, ftp_data, icmp, eco_i, ntp_u, ecr_i, tcp, udp,
    //    Private, pop_3, rje, time, mtp, link, kshell,
    //    remote_job, gopher, ssh, name, whois, discard,
    //    domain, login, imap4, daytime, courier, systat,
    //    ctf, nntp, shell, IRC, nnsp, uucp, echo, supdup,
    //    http_443, exec, printer, efs, klogin, iso_tsap,
    //    hostnames, csnet_ns, pop_2, sunrpc, other
    //};

    public enum SpecificConnectionType
    {
        normal, back, buffer_overflow,
        ftp_write, guess_passwd, imap,
        ipsweep, land, loadmodule,
        multihop, neptune, nmap, perl, phf,
        pod, portsweep, rootkit, satan, smurf,
        spy, teardrop, warezclient, warezmaster
    };

    public enum MiddleSpecificConnectionType
    {
        normal, probe, u2r, r2l, dos
    };

    public enum GenericConnectionType
    {
        normal, suspicious
    };

    public class Row
    {
        public Row(string[] row)
        {
            InputList = new List<double>
            {
                double.Parse(row[0])
            };

            AddToListWithCheck(row[1], Protocols);
            AddToListWithCheck(row[2], Services);
            AddToListWithCheck(row[3], RstBytes);

            var conType = row[row.Length - 1]; //output
            conType = conType.Substring(0, conType.Length - 1); //ignore dot at the end

            GenConType = GetGenericConnectionType(conType);
            MidConType = GetMiddleSpecificConnectionType(conType);
            ConType = GetEnumFromString<SpecificConnectionType>(conType);


            for (int i = 0; i < row.Length - 5; i++)
            {
                ((List<double>)InputList).Add(double.Parse(row[4 + i].Replace('.', ',')));
            }
        }

        private void AddToListWithCheck(string val, Dictionary<string, int> dict)
        {
            if (!dict.ContainsKey(val))
            {
                dict.Add(val, dict.Count);
            }
            ((List<double>)InputList).Add(dict[val]);
        }

        public static Dictionary<string, int> Protocols = new Dictionary<string, int>();
        public static Dictionary<string, int> Services = new Dictionary<string, int>();
        public static Dictionary<string, int> RstBytes = new Dictionary<string, int>();
        public readonly IEnumerable<double> InputList;


        public GenericConnectionType GenConType;
        public MiddleSpecificConnectionType MidConType;
        public SpecificConnectionType ConType;

        private static readonly Dictionary<SpecificConnectionType, MiddleSpecificConnectionType> SpecificToMiddleConnectionTypes =
            new Dictionary<SpecificConnectionType, MiddleSpecificConnectionType>
            {
                {SpecificConnectionType.normal,          MiddleSpecificConnectionType.normal},
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

        private static T GetEnumFromString<T>(string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }

        private static GenericConnectionType GetGenericConnectionType(string s)
        {
            if (s.StartsWith("normal")) return GenericConnectionType.normal;
            return GenericConnectionType.suspicious;
        }

        private static MiddleSpecificConnectionType GetMiddleSpecificConnectionType(string s)
        {
            var specific = GetEnumFromString<SpecificConnectionType>(s);

            return SpecificToMiddleConnectionTypes[specific];
        }

        public double ResType(Type learnType)
        {
            if (learnType == typeof(GenericConnectionType))
                return (double)GenConType;
            if (learnType == typeof(MiddleSpecificConnectionType))
                return (double)MidConType;
            if (learnType == typeof(SpecificConnectionType))
                return (double)ConType;

            throw new Exception("Wrong output type");
        }

        public double[] AsIputArray()
        {
            return InputList.ToArray();
        }

        public static Row[] LoadLinesFromFile(string filePath, long fromLine, long lineCount)
        {
            using (var f = new StreamReader(filePath))
            {
                //skip to needed line
                for (int i = 0; i < fromLine; i++) f.ReadLine();

                var rows = new Row[lineCount];
                //read lines to string
                for (int i = 0; i < lineCount; i++)
                {
                    var readLine = f.ReadLine();
                    if (readLine != null)
                    {
                        var readString = readLine.Split(',');
                        rows[i] = new Row(readString);
                    }
                    else
                    {
                        throw new FileLoadException("File is too short!");
                    }
                }

                return rows;
            }
        }
    }
}