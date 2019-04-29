//-----------------------------------------------------------------------
// <copyright>
//     This Source Code Form is subject to the terms of the Mozilla Public
//     License, v. 2.0. If a copy of the MPL was not distributed with this
//     file, You can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CP3.Derpi
{
    /// <summary>
    /// A utility class for manipulating query strings.
    /// </summary>
    public class QueryString : IEnumerable
    {

        /// <summary>
        /// The internal values of the QueryString, stored as a list of key/value pairs.
        /// </summary>
        private List<KeyValuePair<string, string>> values;

        /// <summary>
        /// Creates an empty QueryString.
        /// </summary>
        public QueryString()
        {
            this.values = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Creates a new QueryString with the values from the given query string.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        public QueryString(string queryString)
        {
            this.values = ParseQueryString(queryString);
        }


        #region Public Methods

        /// <summary>
        /// Adds a value to the QueryString.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Add(string key, string value)
        {
            this.values.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        /// <summary>
        /// Adds a value to the QueryString.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Add(string key, int value) => this.Add(key, value.ToString());

        /// <summary>
        /// Adds an array of values to the QueryString.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Add(string key, string[] values)
        {
            var arrayKey = key + "[]";
            foreach (var value in values) this.Add(arrayKey, value);
            return this;
        }

        /// <summary>
        /// Adds an array of values to the QueryString.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Add(string key, int[] values)
        {
            var arrayKey = key + "[]";
            foreach (var value in values) this.Add(arrayKey, value);
            return this;
        }

        /// <summary>
        /// Removes all entries with the given key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Remove(string key)
        {
            this.values.RemoveAll(v => v.Key == key);
            return this;
        }

        /// <summary>
        /// Replace removes all entries with the given key and replaces them with the given value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Replace(string key, string value) => this.Remove(key).Add(key, value);

        /// <summary>
        /// Replace removes all entries with the given key and replaces them with the given value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Replace(string key, int value) => this.Remove(key).Add(key, value);

        /// <summary>
        /// Replace removes all entries with the given key and replaces them with the given values.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Replace(string key, string[] values) => this.Remove(key + "[]").Add(key, values);

        /// <summary>
        /// Replace removes all entries with the given key and replaces them with the given values.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <returns>Returns the current QueryString object.</returns>
        public QueryString Replace(string key, int[] values) => this.Remove(key + "[]").Add(key, values);

        /// <summary>
        /// Build builds the QueryString and returns it as a string.
        /// </summary>
        /// <returns>Returns the string representation of the QueryString.</returns>
        public string Build() => BuildQueryString(this.values);

        /// <summary>
        /// ToString is an alias to `Build()`. It returns the QueryString in a string format.
        /// </summary>
        /// <returns>Returns the string representation of the QueryString.</returns>
        public override string ToString() => Build();

        #endregion


        #region IEnumerable Implimentation

        /// <summary>
        /// GetEnumerator gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator GetEnumerator() => values.GetEnumerator();

        #endregion


        #region Internal Helpers

        /// <summary>
        /// BuildQuerySegment builds a key=value segment for a query string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns the query segment.</returns>
        private static string BuildQuerySegment(string key, string value)
        {
            if (value == null) return Uri.EscapeDataString(key);
            else return Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString(value);
        }

        /// <summary>
        /// ParseQuerySegment parses a key=value segment of a query string.
        /// </summary>
        /// <param name="segment">The key=value segment.</param>
        /// <returns>Returns a key value pair for the segment.</returns>
        private static KeyValuePair<string, string> ParseQuerySegment(string segment)
        {

            var segmentParts = segment.Split(new char[] { '=' }, 2);

            string key = null;
            if (segmentParts.Length > 0)
            {
                key = Uri.UnescapeDataString(segmentParts[0]);
            }

            string value = null;
            if (segmentParts.Length > 1)
            {
                value = Uri.UnescapeDataString(segmentParts[1]);
            }

            return new KeyValuePair<string, string>(key, value);
        }

        /// <summary>
        /// ParseQueryString parses a query string into a list of key value pairs.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns>Returns a list of key values pairs that represent the query string.</returns>
        private static List<KeyValuePair<string, string>> ParseQueryString(string queryString)
        {
            return SplitQueryString(queryString).Select(segment => ParseQuerySegment(segment)).ToList();
        }

        /// <summary>
        /// BuildQueryString builds a query string from a list of key value pairs. The beginning "?" is not included.
        /// </summary>
        /// <param name="values">The values for the query string.</param>
        /// <returns>Returns the query string.</returns>
        private static string BuildQueryString(List<KeyValuePair<string, string>> values)
        {
            return JoinQueryString(values.Select(v => BuildQuerySegment(v.Key, v.Value)).ToArray());
        }

        /// <summary>
        /// SplitQueryString splits a query string into key=value segments.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns>Returns an array of key=value segments.</returns>
        private static string[] SplitQueryString(string queryString)
        {
            return queryString.TrimStart('?').Split('&');
        }

        /// <summary>
        /// JoinQueryString joins key=value segments together into a query string.
        /// </summary>
        /// <param name="segments">An array of key=value segments.</param>
        /// <returns>Returns a query string.</returns>
        private static string JoinQueryString(string[] segments)
        {
            return string.Join("&", segments);
        }

        #endregion

    }
}
