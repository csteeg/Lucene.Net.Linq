﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Lucene.Net.Linq.Mapping;
using NUnit.Framework;

namespace Lucene.Net.Linq.Tests.Mapping
{
    [TestFixture]
    public class FieldMappingInfoBuilderTests
    {
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public ComplexType ComplexProperty { get; set; }

        private PropertyInfo stringPropertyInfo;

        [SetUp]
        public void SetUp()
        {
            stringPropertyInfo = GetType().GetProperty("StringProperty");
        }

        [Test]
        public void FieldIsPropertyName()
        {
            var context = FieldMappingInfoBuilder.Build<FieldMappingInfoBuilderTests>(stringPropertyInfo);
            Assert.That(context.FieldName, Is.EqualTo(stringPropertyInfo.Name));
        }

        [Test]
        public void RetainsPropertyInfo()
        {
            var context = FieldMappingInfoBuilder.Build<FieldMappingInfoBuilderTests>(stringPropertyInfo);
            Assert.That(context.PropertyInfo, Is.SameAs(stringPropertyInfo));
        }

        [Test]
        public void NoConverterForStrings()
        {
            var context = FieldMappingInfoBuilder.Build<FieldMappingInfoBuilderTests>(stringPropertyInfo);
            Assert.That(context.Converter, Is.Null, "No converter should be necessary for typeof(string)");
        }

        [Test]
        public void BuildFromIntProperty()
        {
            var propertyInfo = GetType().GetProperty("IntProperty");
            var context = FieldMappingInfoBuilder.Build<FieldMappingInfoBuilderTests>(propertyInfo);

            Assert.That(context.Converter, Is.EqualTo(TypeDescriptor.GetConverter(typeof(int))));
        }

        [Test]
        public void BuildThrowsOnUnconvertableType()
        {
            var propertyInfo = GetType().GetProperty("ComplexProperty");
            TestDelegate call = () => FieldMappingInfoBuilder.Build<FieldMappingInfoBuilderTests>(propertyInfo);

            Assert.That(call, Throws.Exception.InstanceOf<NotSupportedException>());
        }

        [Field(Converter = typeof(ComplexTypeConverter))]
        public ComplexType ComplexPropertyWithConverter { get; set; }

        [Test]
        public void BuildFromComplexTypeWithCustomConverter()
        {
            var propertyInfo = GetType().GetProperty("ComplexPropertyWithConverter");
            var context = FieldMappingInfoBuilder.Build<FieldMappingInfoBuilderTests>(propertyInfo);

            Assert.That(context.Converter, Is.InstanceOf<ComplexTypeConverter>());
        }

        [Field("ugly_lucene_field_name")]
        public string FriendlyName { get; set; }

        [Test]
        public void OverrideFieldName()
        {
            var propertyInfo = GetType().GetProperty("FriendlyName");
            var context = FieldMappingInfoBuilder.Build<FieldMappingInfoBuilderTests>(propertyInfo);

            Assert.That(context.FieldName, Is.EqualTo("ugly_lucene_field_name"));
        }

        public class ComplexType
        {
        }

        public class ComplexTypeConverter : TypeConverter
        {
        }

    }
}
