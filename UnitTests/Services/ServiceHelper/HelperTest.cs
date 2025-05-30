﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services.ServiceHelper
{
    [TestClass]
    public sealed class HelperTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var helper = new TestingGround.Services.Helper.Helper();
        }
        [TestMethod]
        public void PathCombineTest()
        {

            var helper = new TestingGround.Services.Helper.Helper();
            Assert.AreEqual("/dir1/file.ext", helper.PathCombine("/dir1", "file.ext"), 
                "Combination rule: '/dir1' + 'file.ext' -> '/dir1/file.ext'");
         
            Assert.AreEqual("/dir2/file2.ext", helper.PathCombine("/dir2", "file2.ext"),
                "Combination rule: '/dir2' + '/file2.ext' -> '/dir2/file2/ext'");

            Assert.AreEqual("/dir/subdir/file.ext", helper.PathCombine("dir", "subdir", "file.ext"),
                "Combination rule: 'dir + 'subdir' + 'file.ext' -> '/dir/subdir/file.ext'");

            Assert.AreEqual(
                "/dir/subdir1/subdir2/subdir3/file.ext",
                helper.PathCombine("/dir/", "/subdir1/", "/subdir2/", "/subdir3/", "/file.ext"),
                "Combination rule: '/dir/' + '/subdir1/' + '/subdir2/' + '/subdir3/'  + '/file.ext' -> '/dir/subdir/file.ext'"
            );

            Assert.AreEqual("/dir1/file.ext", helper.PathCombine(@"\dir1", "\\file.ext"),
                @"Combination rule: '\dir1' + '\file.ext' -> '/dir1/file.ext'");

            Assert.AreEqual("C://dir/file", helper.PathCombine(@"C://dir/file"),
                "Combination rule: 'C://dir/file' -> '/dir2/file2/ext'");

            Assert.AreEqual("/file", helper.PathCombine(@"file"),
                "Combination rule: 'file' -> '/file'");

            Assert.AreEqual("C://dir/file", helper.PathCombine(@"C://dir", "file"),
                "Combination rule: 'file' -> 'C://dir/file'");

            Assert.AreEqual("/file", helper.PathCombine(@"dir", "..", "file"),
                "Combination rule: 'dir' + '..' + 'file' -> '/file'");

            Assert.AreEqual(
                @"/dir2/file",
                helper.PathCombine(@"dir", "../dir2", "file"),
                @"Combination rule: 'dir' + '../dir2' + 'file' -> '/dir2/file'"
            );

            Assert.AreEqual(
                @"/dir/dir2/file",
                helper.PathCombine(@"dir/dir1", "../dir2", "file"),
                @"Combination rule: 'dir/dir1' + '../dir2' + 'file' -> '/dir/dir2/file'"
            );

            Assert.AreEqual
            (
                @"http://dir/sub/file.txt",
                helper.PathCombine(@" http://dir ", " ./sub ", " ./file.txt "),
                @"Combination rule: 'http://dir' + './sub' + './file.txt' -> 'http://dir/sub//file.txt'"
            );
            //Assert.AreEqual("C://file", helper.PathCombine(@"C://dir", "..", "file"),
            //"Combination rule: 'dir' + '..' + 'file' -> '/file'");

        }
    }
}
