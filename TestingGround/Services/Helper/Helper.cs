using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestingGround.Services.Helper
{
    public class Helper
    {
        // public string PathCombine(string directory, string file) => "/dir1/file.ext";

        //public string PathCombine(params string[] parts)
        //{
        //    if(parts.Length <= 1 && parts[0].Contains("://")) return parts[0];
        //    char[] chars = ['/', '\\'];
        //    return string.Join("", from part in parts select part.Contains("://") ? part : $"/{part.TrimEnd(chars).TrimStart(chars)}");
        //}

        //public string PathCombine(params string[] parts)
        //{
        //    char[] chars = ['/', '\\'];
        //    LinkedList<string> list = new LinkedList<string>();
        //    foreach (var part in parts)
        //    {
        //        string[] subs;
        //        if (!part.Contains("://")) subs = part.Split('/', StringSplitOptions.RemoveEmptyEntries);
        //        else subs = [part];
        //        foreach (var sub in subs)
        //        {
        //            if (sub == "..")
        //            {
        //                string? last = list?.Last!.Value;
        //                list?.RemoveLast();
        //                if (last!.Contains("://"))
        //                {
        //                    int index = last.IndexOf('/');
        //                    if(index != -1)
        //                    {
        //                        list?.AddLast(last[..(index + 1)]);
        //                    }
        //                }    
        //            }
        //            else if (sub.Contains(".."))
        //            {
        //                list?.RemoveLast();
        //                list?.AddLast($"/{sub[2..].TrimEnd(chars).TrimStart(chars)}");
        //            }
        //            else list?.AddLast(sub.Contains("://") ? sub : $"/{sub.TrimEnd(chars).TrimStart(chars)}");
        //        }

        //    }
        //    return string.Join("", list!);
        //}

        public String PathCombine(params String[] parts)
        {
            char[] chars = ['/', '\\', ' '];
            LinkedList<String> list = [];
            foreach (String path in parts)
            {
                foreach (String pt in Regex.Split(path, @"(?<!/)/(?!/)"))
                {
                    string part = pt.Trim();
                    if (part == "" || part == ".") continue;
                    if (part == "..") list.RemoveLast();
                    else
                    {
                        int index = part.IndexOf("://");
                        if(index != -1)
                        {
                            index += 3;
                            string disk = part[..index];
                            list.AddLast(disk.Trim());
                            if(part.Length > index)
                            {
                                list.AddLast(part[index..]);
                            }
                        }
                        else
                        {
                            list.AddLast($"/{part.TrimEnd(chars).TrimStart(chars)}");
                        }
                    }
                }
            }

            return String.Join("", list);
        }
    }
}

// Never gonna give you up...