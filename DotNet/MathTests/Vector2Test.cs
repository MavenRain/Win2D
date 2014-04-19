//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//

using System;
using System.Runtime.InteropServices;
using Windows.Math;

#if NO_WINRT
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#endif

namespace MathTests
{
    [TestClass()]
    public class Vector2Test
    {
        static bool Equal(float a, float b)
        {
            return (System.Math.Abs(a - b) < 1e-6);
        }

        static internal bool Equal(Vector2 a, Vector2 b)
        {
            return Equal(a.X, b.X) && Equal(a.Y, b.Y);
        }

        static bool CloseEnough(Vector2[] a, Vector2[] b)
        {
            if ((a == null || b == null) && a != b) return false;
            if (a == b) return true;
            if (a.Length != b.Length) return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (!Equal(a[i], b[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        ///A test for Distance (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2DistanceTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            float expected = (float)System.Math.Sqrt(8);
            float actual;

            actual = Vector2.Distance(a, b);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Distance did not return the expected value.");
        }

        /// <summary>
        ///A test for Distance (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        [Description("Distance from the same point")]
        public void Vector2DistanceTest2()
        {
            Vector2 a = new Vector2(1.051f, 2.05f);
            Vector2 b = new Vector2(1.051f, 2.05f);

            float actual = Vector2.Distance(a, b);
            Assert.AreEqual(0.0f, actual, "Vector2.Distance did not return the expected value.");
        }

        /// <summary>
        ///A test for DistanceSquared (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2DistanceSquaredTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            float expected = 8.0f;
            float actual;

            actual = Vector2.DistanceSquared(a, b);
            Assert.IsTrue(Equal(expected, actual), "Vector2.DistanceSquared did not return the expected value.");
        }

        /// <summary>
        ///A test for Dot (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2DotTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            float expected = 11.0f;
            float actual;

            actual = Vector2.Dot(a, b);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Dot did not return the expected value.");
        }

        /// <summary>
        ///A test for Dot (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        [Description("Dot test for perpendicular vector")]
        public void Vector2DotTest1()
        {
            Vector2 a = new Vector2(1.55f, 1.55f);
            Vector2 b = new Vector2(-1.55f, 1.55f);

            float expected = 0.0f;
            float actual = Vector2.Dot(a, b);
            Assert.AreEqual(expected, actual, "Vector2.Dot did not return the expected value.");
        }

        /// <summary>
        ///A test for Dot (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        [Description("Dot test with specail float values")]
        public void Vector2DotTest2()
        {
            Vector2 a = new Vector2(float.MinValue, float.MinValue);
            Vector2 b = new Vector2(float.MaxValue, float.MaxValue);

            float actual = Vector2.Dot(a, b);
            Assert.IsTrue(float.IsNegativeInfinity(actual), "Vector2.Dot did not return the expected value.");
        }

        /// <summary>
        ///A test for Length ()
        ///</summary>
        [TestMethod]
        public void Vector2LengthTest()
        {
            Vector2 a = new Vector2(2.0f, 4.0f);

            Vector2 target = a;

            float expected = (float)System.Math.Sqrt(20);
            float actual;

            actual = target.Length();

            Assert.IsTrue(Equal(expected, actual), "Vector2.Length did not return the expected value.");
        }

        /// <summary>
        ///A test for Length ()
        ///</summary>
        [TestMethod]
        [Description("Length test where length is zero")]
        public void Vector2LengthTest1()
        {
            Vector2 target = new Vector2();
            target.X = 0.0f;
            target.Y = 0.0f;

            float expected = 0.0f;
            float actual;

            actual = target.Length();

            Assert.IsTrue(Equal(expected, actual), "Vector2.Length did not return the expected value.");
        }

        /// <summary>
        ///A test for LengthSquared ()
        ///</summary>
        [TestMethod]
        public void Vector2LengthSquaredTest()
        {
            Vector2 a = new Vector2(2.0f, 4.0f);

            Vector2 target = a;

            float expected = 20.0f;
            float actual;

            actual = target.LengthSquared();

            Assert.IsTrue(Equal(expected, actual), "Vector2.LengthSquared did not return the expected value.");
        }

        /// <summary>
        ///A test for LengthSquared ()
        ///</summary>
        [TestMethod]
        [Description("LengthSquared test where the result is zero")]
        public void Vector2LengthSquaredTest1()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);

            float expected = 0.0f;
            float actual = a.LengthSquared();

            Assert.AreEqual(expected, actual, "Vector2.LengthSquared did not return the expected value.");
        }

        /// <summary>
        ///A test for Min (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2MinTest()
        {
            Vector2 a = new Vector2(-1.0f, 4.0f);
            Vector2 b = new Vector2(2.0f, 1.0f);

            Vector2 expected = new Vector2(-1.0f, 1.0f);
            Vector2 actual;
            actual = Vector2.Min(a, b);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Min did not return the expected value.");
        }

        [TestMethod]
        public void Vector2MinMaxCodeCoverageTest()
        {
            Vector2 min = new Vector2(0, 0);
            Vector2 max = new Vector2(1, 1);
            Vector2 actual;

            // Min.
            actual = Vector2.Min(min, max);
            Assert.AreEqual(actual, min);

            actual = Vector2.Min(max, min);
            Assert.AreEqual(actual, min);

            // Max.
            actual = Vector2.Max(min, max);
            Assert.AreEqual(actual, max);

            actual = Vector2.Max(max, min);
            Assert.AreEqual(actual, max);
        }

        /// <summary>
        ///A test for Max (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2MaxTest()
        {
            Vector2 a = new Vector2(-1.0f, 4.0f);
            Vector2 b = new Vector2(2.0f, 1.0f);

            Vector2 expected = new Vector2(2.0f, 4.0f);
            Vector2 actual;
            actual = Vector2.Max(a, b);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Max did not return the expected value.");
        }

        /// <summary>
        ///A test for Clamp (Vector2, Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2ClampTest()
        {
            Vector2 a = new Vector2(0.5f, 0.3f);
            Vector2 min = new Vector2(0.0f, 0.1f);
            Vector2 max = new Vector2(1.0f, 1.1f);

            // Normal case.
            // Case N1: specfied value is in the range.
            Vector2 expected = new Vector2(0.5f, 0.3f);
            Vector2 actual = Vector2.Clamp(a, min, max);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Clamp did not return the expected value.");

            // Normal case.
            // Case N2: specfied value is bigger than max value.
            a = new Vector2(2.0f, 3.0f);
            expected = max;
            actual = Vector2.Clamp(a, min, max);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Clamp did not return the expected value.");

            // Case N3: specfied value is smaller than max value.
            a = new Vector2(-1.0f, -2.0f);
            expected = min;
            actual = Vector2.Clamp(a, min, max);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Clamp did not return the expected value.");

            // Case N4: combination case.
            a = new Vector2(-2.0f, 4.0f);
            expected = new Vector2(min.X, max.Y);
            actual = Vector2.Clamp(a, min, max);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Clamp did not return the expected value.");

            // User specfied min value is bigger than max value.
            max = new Vector2(0.0f, 0.1f);
            min = new Vector2(1.0f, 1.1f);

            // Case W1: specfied value is in the range.
            a = new Vector2(0.5f, 0.3f);
            expected = min;
            actual = Vector2.Clamp(a, min, max);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Clamp did not return the expected value.");

            // Normal case.
            // Case W2: specfied value is bigger than max and min value.
            a = new Vector2(2.0f, 3.0f);
            expected = min;
            actual = Vector2.Clamp(a, min, max);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Clamp did not return the expected value.");

            // Case W3: specfied value is smaller than min and max value.
            a = new Vector2(-1.0f, -2.0f);
            expected = min;
            actual = Vector2.Clamp(a, min, max);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Clamp did not return the expected value.");
        }

        #region Lerp Tests

        /// <summary>
        ///A test for Lerp (Vector2, Vector2, float)
        ///</summary>
        [TestMethod]
        public void Vector2LerpTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);

            float t = 0.5f;

            Vector2 expected = new Vector2(2.0f, 3.0f);
            Vector2 actual;
            actual = Vector2.Lerp(a, b, t);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        /// <summary>
        ///A test for Lerp (Vector2, Vector2, float)
        ///</summary>
        [TestMethod]
        [Description("Lerp test with factor zero")]
        public void Vector2LerpTest1()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(3.18f, 4.25f);

            float t = 0.0f;
            Vector2 expected = Vector2.Zero;
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        /// <summary>
        ///A test for Lerp (Vector2, Vector2, float)
        ///</summary>
        [TestMethod]
        [Description("Lerp test with factor one")]
        public void Vector2LerpTest2()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(3.18f, 4.25f);

            float t = 1.0f;
            Vector2 expected = new Vector2(3.18f, 4.25f);
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        /// <summary>
        ///A test for Lerp (Vector2, Vector2, float)
        ///</summary>
        [TestMethod]
        [Description("Lerp test with factor > 1")]
        public void Vector2LerpTest3()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(3.18f, 4.25f);

            float t = 2.0f;
            Vector2 expected = b * 2.0f;
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        /// <summary>
        ///A test for Lerp (Vector2, Vector2, float)
        ///</summary>
        [TestMethod]
        [Description("Lerp test with factor < 0")]
        public void Vector2LerpTest4()
        {
            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(3.18f, 4.25f);

            float t = -2.0f;
            Vector2 expected = -(b * 2.0f);
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        /// <summary>
        ///A test for Lerp (Vector2, Vector2, float)
        ///</summary>
        [TestMethod]
        [Description("Lerp test with special float value")]
        public void Vector2LerpTest5()
        {
            Vector2 a = new Vector2(45.67f, 90.0f);
            Vector2 b = new Vector2(float.PositiveInfinity, float.NegativeInfinity);

            float t = 0.408f;
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.IsTrue(float.IsPositiveInfinity(actual.X), "Vector2.Lerp did not return the expected value.");
            Assert.IsTrue(float.IsNegativeInfinity(actual.Y), "Vector2.Lerp did not return the expected value.");
        }

        /// <summary>
        ///A test for Lerp (Vector2, Vector2, float)
        ///</summary>
        [TestMethod]
        [Description("Lerp test from the same point")]
        public void Vector2LerpTest6()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            float t = 0.5f;

            Vector2 expected = new Vector2(1.0f, 2.0f);
            Vector2 actual = Vector2.Lerp(a, b, t);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Lerp did not return the expected value.");
        }

        #endregion

        /// <summary>
        ///A test for Transform(Vector2, Matrix4x4)
        ///</summary>
        [TestMethod]
        public void Vector2TransformTest()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector2 expected = new Vector2(10.316987f, 22.183012f);
            Vector2 actual;

            actual = Vector2.Transform(v, m);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        }

        /// <summary>
        ///A test for Transform(Vector2, Matrix3x2)
        ///</summary>
        [TestMethod]
        public void Vector2Transform3x2Test()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Matrix3x2 m = Matrix3x2.CreateRotation(MathHelper.ToRadians(30.0f));
            m.M31 = 10.0f;
            m.M32 = 20.0f;

            Vector2 expected = new Vector2(9.866025f, 22.23205f);
            Vector2 actual;

            actual = Vector2.Transform(v, m);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        }

        /// <summary>
        ///A test for TransformNormal (Vector2, Matrix4x4)
        ///</summary>
        [TestMethod]
        public void Vector2TransformNormalTest()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            m.M41 = 10.0f;
            m.M42 = 20.0f;
            m.M43 = 30.0f;

            Vector2 expected = new Vector2(0.3169873f, 2.18301272f);
            Vector2 actual;

            actual = Vector2.TransformNormal(v, m);
            Assert.AreEqual(expected, actual, "Vector2.TransformNormal did not return the expected value.");
        }

        /// <summary>
        ///A test for TransformNormal (Vector2, Matrix3x2)
        ///</summary>
        [TestMethod]
        public void Vector2TransformNormal3x2Test()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Matrix3x2 m = Matrix3x2.CreateRotation(MathHelper.ToRadians(30.0f));
            m.M31 = 10.0f;
            m.M32 = 20.0f;

            Vector2 expected = new Vector2(-0.133974612f, 2.232051f);
            Vector2 actual;

            actual = Vector2.TransformNormal(v, m);
            Assert.AreEqual(expected, actual, "Vector2.TransformNormal did not return the expected value.");
        }

        #region Transform vector by Quaternion

        /// <summary>
        ///A test for Transform (Vector2, Quaternion)
        ///</summary>
        [TestMethod]
        [Description("Transform Vector2 test")]
        public void Vector2TransformByQuaternionTest()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);

            Matrix4x4 m =
                Matrix4x4.CreateRotationX(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationY(MathHelper.ToRadians(30.0f)) *
                Matrix4x4.CreateRotationZ(MathHelper.ToRadians(30.0f));
            Quaternion q = Quaternion.CreateFromRotationMatrix(m);

            Vector2 expected = Vector2.Transform(v, m);
            Vector2 actual = Vector2.Transform(v, q);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        }

        /// <summary>
        ///A test for Transform (Vector2, Quaternion)
        ///</summary>
        [TestMethod]
        [Description("Transform Vector2 with zero quaternion")]
        public void Vector2TransformByQuaternionTest1()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Quaternion q = new Quaternion();
            Vector2 expected = v;

            Vector2 actual = Vector2.Transform(v, q);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        }

        /// <summary>
        ///A test for Transform (Vector2, Quaternion)
        ///</summary>
        [TestMethod]
        [Description("Transform Vector2 with identity quaternion")]
        public void Vector2TransformByQuaternionTest2()
        {
            Vector2 v = new Vector2(1.0f, 2.0f);
            Quaternion q = Quaternion.Identity;
            Vector2 expected = v;

            Vector2 actual = Vector2.Transform(v, q);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Transform did not return the expected value.");
        }

        #endregion

        /// <summary>
        ///A test for Normalize (Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2NormalizeTest()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            Vector2 expected = new Vector2(0.554700196225229122018341733457f, 0.8320502943378436830275126001855f);
            Vector2 actual;

            actual = Vector2.Normalize(a);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Normalize did not return the expected value.");
        }

        /// <summary>
        ///A test for Normalize (Vector2)
        ///</summary>
        [TestMethod]
        [Description("Normalize zero length vector")]
        public void Vector2NormalizeTest1()
        {
            Vector2 a = new Vector2(); // no parameter, default to 0.0f
            Vector2 actual = Vector2.Normalize(a);
            Assert.IsTrue(float.IsNaN(actual.X) && float.IsNaN(actual.Y), "Vector2.Normalize did not return the expected value.");
        }

        /// <summary>
        ///A test for Normalize (Vector2)
        ///</summary>
        [TestMethod]
        [Description("Normalize infinite length vector")]
        public void Vector2NormalizeTest2()
        {
            Vector2 a = new Vector2(float.MaxValue, float.MaxValue);
            Vector2 actual = Vector2.Normalize(a);
            Vector2 expected = new Vector2(0, 0);
            Assert.AreEqual(expected, actual, "Vector2.Normalize did not return the expected value.");
        }

        /// <summary>
        ///A test for operator - (Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2UnaryNegationTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);

            Vector2 expected = new Vector2(-1.0f, -2.0f);
            Vector2 actual;

            actual = -a;

            Assert.IsTrue(Equal(expected, actual), "Vector2.operator - did not return the expected value.");
        }

        /// <summary>
        ///A test for operator - (Vector2)
        ///</summary>
        [TestMethod]
        [Description("Negate test with special float value")]
        public void Vector2UnaryNegationTest1()
        {
            Vector2 a = new Vector2(float.PositiveInfinity, float.NegativeInfinity);

            Vector2 actual = -a;

            Assert.IsTrue(float.IsNegativeInfinity(actual.X), "Vector2.Lerp did not return the expected value.");
            Assert.IsTrue(float.IsPositiveInfinity(actual.Y), "Vector2.Lerp did not return the expected value.");
        }

        /// <summary>
        ///A test for operator - (Vector2)
        ///</summary>
        [TestMethod]
        [Description("Negate test with special float value")]
        public void Vector2UnaryNegationTest2()
        {
            Vector2 a = new Vector2(float.NaN, 0.0f);
            Vector2 actual = -a;

            Assert.IsTrue(float.IsNaN(actual.X), "Vector2.Lerp did not return the expected value.");
            Assert.IsTrue(float.Equals(0.0f, actual.Y), "Vector2.Lerp did not return the expected value.");
        }

        /// <summary>
        ///A test for operator - (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2SubtractionTest()
        {
            Vector2 a = new Vector2(1.0f, 3.0f);
            Vector2 b = new Vector2(2.0f, 1.5f);

            Vector2 expected = new Vector2(-1.0f, 1.5f);
            Vector2 actual;

            actual = a - b;

            Assert.IsTrue(Equal(expected, actual), "Vector2.operator - did not return the expected value.");
        }

        /// <summary>
        ///A test for operator * (Vector2, float)
        ///</summary>
        [TestMethod]
        public void Vector2MultiplyTest()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            float factor = 2.0f;

            Vector2 expected = new Vector2(4.0f, 6.0f);
            Vector2 actual;

            actual = a * factor;
            Assert.IsTrue(Equal(expected, actual), "Vector2.operator * did not return the expected value.");
        }

        /// <summary>
        ///A test for operator * (float, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2MultiplyTest4()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            float factor = 2.0f;

            Vector2 expected = new Vector2(4.0f, 6.0f);
            Vector2 actual;

            actual = factor * a;
            Assert.IsTrue(Equal(expected, actual), "Vector2.operator * did not return the expected value.");
        }

        /// <summary>
        ///A test for operator * (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2MultiplyTest1()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            Vector2 b = new Vector2(4.0f, 5.0f);

            Vector2 expected = new Vector2(8.0f, 15.0f);
            Vector2 actual;

            actual = a * b;

            Assert.IsTrue(Equal(expected, actual), "Vector2.operator * did not return the expected value.");
        }

        /// <summary>
        ///A test for operator / (Vector2, float)
        ///</summary>
        [TestMethod]
        public void Vector2DivisionTest()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);

            float div = 2.0f;

            Vector2 expected = new Vector2(1.0f, 1.5f);
            Vector2 actual;

            actual = a / div;

            Assert.IsTrue(Equal(expected, actual), "Vector2.operator / did not return the expected value.");
        }

        /// <summary>
        ///A test for operator / (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2DivisionTest1()
        {
            Vector2 a = new Vector2(2.0f, 3.0f);
            Vector2 b = new Vector2(4.0f, 5.0f);

            Vector2 expected = new Vector2(2.0f / 4.0f, 3.0f / 5.0f);
            Vector2 actual;

            actual = a / b;

            Assert.IsTrue(Equal(expected, actual), "Vector2.operator / did not return the expected value.");
        }

        /// <summary>
        ///A test for operator / (Vector2, float)
        ///</summary>
        [TestMethod]
        [Description("Divide by zero")]
        public void Vector2DivisionTest2()
        {
            Vector2 a = new Vector2(-2.0f, 3.0f);

            float div = 0.0f;

            Vector2 actual = a / div;

            Assert.IsTrue(float.IsNegativeInfinity(actual.X), "Vector2.operator / did not return the expected value.");
            Assert.IsTrue(float.IsPositiveInfinity(actual.Y), "Vector2.operator / did not return the expected value.");
        }

        /// <summary>
        ///A test for operator / (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        [Description("Divide by zero")]
        public void Vector2DivisionTest3()
        {
            Vector2 a = new Vector2(0.047f, -3.0f);
            Vector2 b = new Vector2();

            Vector2 actual = a / b;

            Assert.IsTrue(float.IsInfinity(actual.X), "Vector2.operator / did not return the expected value.");
            Assert.IsTrue(float.IsInfinity(actual.Y), "Vector2.operator / did not return the expected value.");
        }

        /// <summary>
        ///A test for operator + (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2AdditionTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);

            Vector2 b = new Vector2(3.0f, 4.0f);

            Vector2 expected = new Vector2(4.0f, 6.0f);
            Vector2 actual;

            actual = a + b;

            Assert.IsTrue(Equal(expected, actual), "Vector2.operator + did not return the expected value.");
        }

        /// <summary>
        ///A test for Vector2 (float, float)
        ///</summary>
        [TestMethod]
        public void Vector2ConstructorTest()
        {
            float x = 1.0f;
            float y = 2.0f;

            Vector2 target = new Vector2(x, y);
            Assert.IsTrue(Equal(target.X, x) && Equal(target.Y, y), "Vector2(x,y) constructor did not return the expected value.");
        }

        /// <summary>
        ///A test for Vector2 (Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2ConstructorTest1()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);

            Vector2 target = a;
            Assert.IsTrue(Equal(target, a), "Vector2( Vector2 ) constructor did not return the expected value.");
        }


        /// <summary>
        ///A test for Vector2 ()
        ///</summary>
        [TestMethod]
        [Description("Constructor with no parameter")]
        public void Vector2ConstructorTest2()
        {
            Vector2 target = new Vector2();
            Assert.AreEqual(target.X, 0.0f, "Vector2() constructor did not return the expected value.");
            Assert.AreEqual(target.Y, 0.0f, "Vector2() constructor did not return the expected value.");
        }

        /// <summary>
        ///A test for Vector2 (float, float)
        ///</summary>
        [TestMethod]
        [Description("Constructor with special floating values")]
        public void Vector2ConstructorTest3()
        {
            Vector2 target = new Vector2(float.NaN, float.MaxValue);
            Assert.AreEqual(target.X, float.NaN, "Vector2(x,y) constructor did not return the expected value.");
            Assert.AreEqual(target.Y, float.MaxValue, "Vector2(x,y) constructor did not return the expected value.");
        }

        /// <summary>
        ///A test for ToString ()
        ///</summary>
        [TestMethod]
        [Description("ToString test for Vector2")]
        public void Vector2ToStringTest()
        {
            Vector2 target = new Vector2(1.0f, 2.2f);

            string expected = "{X:1 Y:2.2}";
            string actual;
            actual = target.ToString();

            Assert.AreEqual(expected, actual, "Vector2.ToString did not return the expected value.");
        }

        /// <summary>
        ///A test for Add (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2AddTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(5.0f, 6.0f);

            Vector2 expected = new Vector2(6.0f, 8.0f);
            Vector2 actual;

            actual = Vector2.Add(a, b);
            Assert.AreEqual(expected, actual, "Vector2.Add did not return the expected value.");
        }

        /// <summary>
        ///A test for Divide (Vector2, float)
        ///</summary>
        [TestMethod]
        public void Vector2DivideTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            float div = 2.0f;
            Vector2 expected = new Vector2(0.5f, 1.0f);
            Vector2 actual;
            actual = Vector2.Divide(a, div);
            Assert.AreEqual(expected, actual, "Vector2.Divide did not return the expected value.");
        }

        /// <summary>
        ///A test for Divide (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2DivideTest1()
        {
            Vector2 a = new Vector2(1.0f, 6.0f);
            Vector2 b = new Vector2(5.0f, 2.0f);

            Vector2 expected = new Vector2(1.0f / 5.0f, 6.0f / 2.0f);
            Vector2 actual;

            actual = Vector2.Divide(a, b);
            Assert.AreEqual(expected, actual, "Vector2.Divide did not return the expected value.");
        }

        /// <summary>
        ///A test for Equals (object)
        ///</summary>
        [TestMethod]
        public void Vector2EqualsTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            // case 1: compare between same values
            object obj = b;

            bool expected = true;
            bool actual = a.Equals(obj);
            Assert.AreEqual(expected, actual, "Vector2.Equals did not return the expected value.");

            // case 2: compare between different values
            b.X = 10.0f;
            obj = b;
            expected = false;
            actual = a.Equals(obj);
            Assert.AreEqual(expected, actual, "Vector2.Equals did not return the expected value.");

            // case 3: compare between different types.
            obj = new Quaternion();
            expected = false;
            actual = a.Equals(obj);
            Assert.AreEqual(expected, actual, "Vector2.Equals did not return the expected value.");

            // case 3: compare against null.
            obj = null;
            expected = false;
            actual = a.Equals(obj);
            Assert.AreEqual(expected, actual, "Vector2.Equals did not return the expected value.");
        }

        /// <summary>
        ///A test for GetHashCode ()
        ///</summary>
        [TestMethod]
        public void Vector2GetHashCodeTest()
        {
            Vector2 target = new Vector2(1.0f, 2.0f);

            int expected = target.X.GetHashCode() + target.Y.GetHashCode();
            int actual;

            actual = target.GetHashCode();

            Assert.AreEqual(expected, actual, "Vector2.GetHashCode did not return the expected value.");
        }

        /// <summary>
        ///A test for Multiply (Vector2, float)
        ///</summary>
        [TestMethod]
        public void Vector2MultiplyTest2()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            float factor = 2.0f;
            Vector2 expected = new Vector2(2.0f, 4.0f);
            Vector2 actual = Vector2.Multiply(a, factor);
            Assert.AreEqual(expected, actual, "Vector2.Multiply did not return the expected value.");
        }

        /// <summary>
        ///A test for Multiply (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2MultiplyTest3()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(5.0f, 6.0f);

            Vector2 expected = new Vector2(5.0f, 12.0f);
            Vector2 actual;

            actual = Vector2.Multiply(a, b);
            Assert.AreEqual(expected, actual, "Vector2.Multiply did not return the expected value.");
        }

        /// <summary>
        ///A test for Negate (Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2NegateTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);

            Vector2 expected = new Vector2(-1.0f, -2.0f);
            Vector2 actual;

            actual = Vector2.Negate(a);
            Assert.AreEqual(expected, actual, "Vector2.Negate did not return the expected value.");
        }

        /// <summary>
        ///A test for operator != (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2InequalityTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            // case 1: compare between same values
            bool expected = false;
            bool actual = a != b;
            Assert.AreEqual(expected, actual, "Vector2.operator != did not return the expected value.");

            // case 2: compare between different values
            b.X = 10.0f;
            expected = true;
            actual = a != b;
            Assert.AreEqual(expected, actual, "Vector2.operator != did not return the expected value.");
        }

        /// <summary>
        ///A test for operator == (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2EqualityTest()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            // case 1: compare between same values
            bool expected = true;
            bool actual = a == b;
            Assert.AreEqual(expected, actual, "Vector2.operator == did not return the expected value.");

            // case 2: compare between different values
            b.X = 10.0f;
            expected = false;
            actual = a == b;
            Assert.AreEqual(expected, actual, "Vector2.operator == did not return the expected value.");
        }

        /// <summary>
        ///A test for Subtract (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2SubtractTest()
        {
            Vector2 a = new Vector2(1.0f, 6.0f);
            Vector2 b = new Vector2(5.0f, 2.0f);

            Vector2 expected = new Vector2(-4.0f, 4.0f);
            Vector2 actual;

            actual = Vector2.Subtract(a, b);
            Assert.AreEqual(expected, actual, "Vector2.Subtract did not return the expected value.");
        }

        /// <summary>
        ///A test for UnitX
        ///</summary>
        [TestMethod]
        public void Vector2UnitXTest()
        {
            Vector2 val = new Vector2(1.0f, 0.0f);
            Assert.AreEqual(val, Vector2.UnitX, "Vector2.UnitX was not set correctly.");
        }

        /// <summary>
        ///A test for UnitY
        ///</summary>
        [TestMethod]
        public void Vector2UnitYTest()
        {
            Vector2 val = new Vector2(0.0f, 1.0f);
            Assert.AreEqual(val, Vector2.UnitY, "Vector2.UnitY was not set correctly.");
        }

        /// <summary>
        ///A test for One
        ///</summary>
        [TestMethod]
        public void Vector2OneTest()
        {
            Vector2 val = new Vector2(1.0f, 1.0f);
            Assert.AreEqual(val, Vector2.One, "Vector2.One was not set correctly.");
        }

        /// <summary>
        ///A test for Zero
        ///</summary>
        [TestMethod]
        public void Vector2ZeroTest()
        {
            Vector2 val = new Vector2(0.0f, 0.0f);
            Assert.AreEqual(val, Vector2.Zero, "Vector2.Zero was not set correctly.");
        }

        /// <summary>
        ///A test for Equals (Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2EqualsTest1()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(1.0f, 2.0f);

            // case 1: compare between same values
            bool expected = true;
            bool actual = a.Equals(b);
            Assert.AreEqual(expected, actual, "Vector2.Equals did not return the expected value.");

            // case 2: compare between different values
            b.X = 10.0f;
            expected = false;
            actual = a.Equals(b);
            Assert.AreEqual(expected, actual, "Vector2.Equals did not return the expected value.");
        }

        /// <summary>
        ///A test for Vector2 (float)
        ///</summary>
        [TestMethod]
        public void Vector2ConstructorTest4()
        {
            float value = 1.0f;
            Vector2 target = new Vector2(value);

            Vector2 expected = new Vector2(value, value);
            Assert.AreEqual(expected, target, "Vector2.cstr did not return the expected value.");

            value = 2.0f;
            target = new Vector2(value);
            expected = new Vector2(value, value);
            Assert.AreEqual(expected, target, "Vector2.cstr did not return the expected value.");
        }

        /// <summary>
        ///A test for Vector2 comparison involving NaN values
        ///</summary>
        [TestMethod]
        public void Vector2EqualsNanTest()
        {
            Vector2 a = new Vector2(float.NaN, 0);
            Vector2 b = new Vector2(0, float.NaN);

            Assert.IsFalse(a == Vector2.Zero);
            Assert.IsFalse(b == Vector2.Zero);

            Assert.IsTrue(a != Vector2.Zero);
            Assert.IsTrue(b != Vector2.Zero);

            Assert.IsFalse(a.Equals(Vector2.Zero));
            Assert.IsFalse(b.Equals(Vector2.Zero));

            // Counterintuitive result - IEEE rules for NaN comparison are weird!
            Assert.IsFalse(a.Equals(a));
            Assert.IsFalse(b.Equals(b));
        }

        #region Reflect Tests

        /// <summary>
        ///A test for Reflect (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        public void Vector2ReflectTest()
        {
            Vector2 a = Vector2.Normalize(new Vector2(1.0f, 1.0f));

            // Reflect on XZ plane.
            Vector2 n = new Vector2(0.0f, 1.0f);
            Vector2 expected = new Vector2(a.X, -a.Y);
            Vector2 actual = Vector2.Reflect(a, n);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Reflect did not return the expected value.");

            // Reflect on XY plane.
            n = new Vector2(0.0f, 0.0f);
            expected = new Vector2(a.X, a.Y);
            actual = Vector2.Reflect(a, n);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Reflect did not return the expected value.");

            // Reflect on YZ plane.
            n = new Vector2(1.0f, 0.0f);
            expected = new Vector2(-a.X, a.Y);
            actual = Vector2.Reflect(a, n);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Reflect did not return the expected value.");
        }

        /// <summary>
        ///A test for Reflect (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        [Description("Reflection when normal and source are the same")]
        public void Vector2ReflectTest1()
        {
            Vector2 n = new Vector2(0.45f, 1.28f);
            n = Vector2.Normalize(n);
            Vector2 a = n;

            Vector2 expected = -n;
            Vector2 actual = Vector2.Reflect(a, n);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Reflect did not return the expected value.");
        }

        /// <summary>
        ///A test for Reflect (Vector2, Vector2)
        ///</summary>
        [TestMethod]
        [Description("Reflection when normal and source are negation")]
        public void Vector2ReflectTest2()
        {
            Vector2 n = new Vector2(0.45f, 1.28f);
            n = Vector2.Normalize(n);
            Vector2 a = -n;

            Vector2 expected = n;
            Vector2 actual = Vector2.Reflect(a, n);
            Assert.IsTrue(Equal(expected, actual), "Vector2.Reflect did not return the expected value.");
        }

        #endregion

        #region WinRT conversions
#if !NO_WINRT
        
        /// <summary>
        ///A test for Vector2 -> Size conversion
        ///</summary>
        [TestMethod]
        public void Vector2ToSizeTest()
        {
            Vector2 vector = new Vector2(23, 42);

            Windows.Foundation.Size result = vector;

            Assert.AreEqual(23.0, result.Width);
            Assert.AreEqual(42.0, result.Height);
        }

        /// <summary>
        ///A test for Vector2 -> Point conversion
        ///</summary>
        [TestMethod]
        public void Vector2ToPointTest()
        {
            Vector2 vector = new Vector2(23, 42);

            Windows.Foundation.Point result = vector;

            Assert.AreEqual(23.0, result.X);
            Assert.AreEqual(42.0, result.Y);
        }

        /// <summary>
        ///A test for Size -> Vector2 conversion
        ///</summary>
        [TestMethod]
        public void Vector2FromSizeTest()
        {
            var size = new Windows.Foundation.Size(23, 42);

            Vector2 result = size;

            Assert.AreEqual(23.0f, result.X);
            Assert.AreEqual(42.0f, result.Y);
        }

        /// <summary>
        ///A test for Point -> Vector2 conversion
        ///</summary>
        [TestMethod]
        public void Vector2FromPointTest()
        {
            var point = new Windows.Foundation.Point(23, 42);

            Vector2 result = point;

            Assert.AreEqual(23.0f, result.X);
            Assert.AreEqual(42.0f, result.Y);
        }

#endif // !NO_WINRT
        #endregion
        
        /// <summary>
        ///A test to make sure these types are blittable directly into GPU buffer memory layouts
        ///</summary>
        [TestMethod]
        public unsafe void Vector2SizeofTest()
        {
            Assert.AreEqual(8, sizeof(Vector2));
            Assert.AreEqual(16, sizeof(Vector2_2x));
            Assert.AreEqual(12, sizeof(Vector2PlusFloat));
            Assert.AreEqual(24, sizeof(Vector2PlusFloat_2x));
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector2_2x
        {
            Vector2 a;
            Vector2 b;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector2PlusFloat
        {
            Vector2 v;
            float f;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct Vector2PlusFloat_2x
        {
            Vector2PlusFloat a;
            Vector2PlusFloat b;
        }
    }
}
