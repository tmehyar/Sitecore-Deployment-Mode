using Sitecore.Data;

namespace DeploymentMode
{
	internal class Templates
	{
		internal struct DeploymentMode
		{
			internal static ID TemplateID => ID.Parse("{DBC1B70E-1B90-4CE7-B691-4462A3C021AB}");

			internal struct Fields
			{
				internal static ID DeploymentModeOn => ID.Parse("{23993326-4A59-407A-808D-8B3BF41AC763}");

				internal struct LockOutUsers
				{
					internal static ID LockOutUsersOn => ID.Parse("{0F28CB3A-C757-4377-961C-78AE7FBC9FB2}");
					internal static ID ExcludedRoles => ID.Parse("{C1B03415-FBC4-439B-BCC0-237AF5D76613}");
				}

				internal struct PreventPublishing
				{
					internal static ID PreventPublishingOn => ID.Parse("{10927F27-8295-4703-9FA2-A0DC08CC0324}");
					internal static ID AllowAdminToPublish => ID.Parse("{2864B219-B584-4597-8683-3FEB5ABD916C}");
				}
			}
		}
	}
}
