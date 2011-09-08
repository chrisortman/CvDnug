

Setup:

  1. Add new mvc project
	2. update nuget packages
	3. merge folders, web.config, global, packages, scripts styles
		1. Copy content folder
		2. get rid of scripts in old project (maybe depends on how much js you have)
		3. copy jquery and modernizer scripts, don't need microsoft* ones
		4. I like to delete as I go
		5. Create controllers
		6. create models
			1. Under my models i wind up with some subsections

		7. copy views folder
		8. copy packages.config (might want to remove EF and jquery.vsdoc)
		9. Copy project file settings
			1. ProjectTypeGUID
			2. References
				1. System.Web.Extensions
				2. System.Web.Abstractions
				3. System.Web.Routing
				4. System.ComponentModel.DataAnnotations
				5. System.Web.Mvc
				6. System.Web.WebPages
				7. System.Web.Helpers


		10. Global.asax
		11. Web.config
			1. appSettings
			2. system.web/compilation
			3. system.web/pages
			4. assemblyBinding

		12. Add controller to test.

	4. MasterPage vs Layout
		1. Javascript
		2. Stylesheets
		3. Merge layout markup
			1. Menu control


	5. The importance of routes
		1. Simple MVC Form
		2. Map about with MapPageRoute
		3. Map about with MapWebFormsPage
		4. Convert about and map with redirect
		5. Unit test the routes

	6. Custom Model Binder & Validator
	7. Filters
	8. Custom Object template



Resources:
Custom validators http://www.devtrends.co.uk/blog/the-complete-guide-to-validation-in-asp.net-mvc-3-part-2
