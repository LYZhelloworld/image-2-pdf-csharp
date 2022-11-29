// <copyright file="IDocument.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System;
    using iText.Layout;
    using iText.Layout.Element;

    /// <inheritdoc cref="Document"/>
    public interface IDocument : IWrapper<Document>, IDisposable
    {
        /// <inheritdoc cref="Document.Add(AreaBreak)"/>
        IDocument Add(IAreaBreak areaBreak);

        /// <inheritdoc cref="Document.Add(IBlockElement)"/>
        IDocument Add(IImage element);

        /// <inheritdoc cref="Document.SetMargins(float, float, float, float)"/>
        void SetMargins(float topMargin, float rightMargin, float bottomMargin, float leftMargin);

        /// <inheritdoc cref="Document.Close"/>
        void Close();
    }
}
