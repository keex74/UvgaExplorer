// <copyright file="IImageTransformer.cs" company="Keex">
// Released under the Creative Commons CC0 license into the public domain.
// Refer to the LICENSE file for further information.
// Originally written by Keex in 2025.
// </copyright>

namespace UvgaExplorer.ImageTransformation
{
    /// <summary>
    /// Defines an interface for classes that can transform an image.
    /// </summary>
    internal interface IImageTransformer
    {
        /// <summary>
        /// Gets a name for the transformer.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a description of the transformer.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Transform an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="configurationControl">The object created prior to the application by the <see cref="GetConfigurationControl"/> function.</param>
        /// <returns>The transformed image, or null if the transformation can't be applied.</returns>
        public Bitmap? TransformImage(Bitmap image, Control? configurationControl);

        /// <summary>
        /// Get a configuration control.
        /// </summary>
        /// <param name="image">The bitmap that should be transformed in the upcoming <see cref="TransformImage(Bitmap, Control?)"/> call.</param>
        /// <returns>The configuration control, or null if no control is available.</returns>
        public Control? GetConfigurationControl(Bitmap image);
    }
}
