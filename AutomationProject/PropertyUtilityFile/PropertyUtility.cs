using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

namespace PropertyUtilityFile
{
    public class PropertyUtility
    {
        // Method to load resources from a .resx file into a Dictionary<string, string>
        // Method to load resources from a .resx file into a Dictionary<string, string>
        public Dictionary<string, string> LoadResources(string resourceFileName)
        {
            var resourceDictionary = new Dictionary<string, string>();

            // Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Create ResourceManager instance, replace "YourNamespace" with your actual namespace
            ResourceManager resourceManager = new ResourceManager($"DemoQAFramework.resources.{resourceFileName}", assembly);

            try
            {
                // Get the ResourceSet for the default culture
                ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);

                if (resourceSet != null)
                {
                    foreach (DictionaryEntry entry in resourceSet)
                    {
                        // Add to dictionary
                        resourceDictionary.Add(entry.Key.ToString(), entry.Value.ToString());
                    }
                }
            }
            catch (MissingManifestResourceException)
            {
                Console.WriteLine($"Resource file not found: {resourceFileName}.resx");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading resource file: {e.Message}");
            }

            return resourceDictionary;
        }
    }
}