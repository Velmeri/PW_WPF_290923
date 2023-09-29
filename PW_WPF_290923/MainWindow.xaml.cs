using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PW_WPF_290923
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>

	public partial class MainWindow : Window
	{
		public enum Language
		{
			ENG,
			UKR
		}
		Language currentLanguage = Language.ENG;

		Dictionary<string, Dictionary<Language, string>> buttonTranslations = new Dictionary<string, Dictionary<Language, string>>
		{
			{ "b1", new Dictionary<Language, string>
				{
					{ Language.ENG, "Menu" },
					{ Language.UKR, "Меню" }
				}
			},
			{ "b2", new Dictionary<Language, string>
				{
					{ Language.ENG, "Back" },
					{ Language.UKR, "Назад" }
				}
			},
			{ "b3", new Dictionary<Language, string>
				{
					{ Language.ENG, "Settings" },
					{ Language.UKR, "Налаштування" }
				}
			},
			{ "b4", new Dictionary<Language, string>
				{
					{ Language.ENG, "Exit" },
					{ Language.UKR, "Вихід" }
				}
			},
			{ "b5", new Dictionary<Language, string>
				{
					{ Language.ENG, "Help" },
					{ Language.UKR, "Довідка" }
				}
			}
		};

		public MainWindow()
		{
			InitializeComponent();
			foreach (var button in new[] { b1, b2, b3, b4, b5 }) {
				UpdateButtonTranslation(button, currentLanguage);
			}
		}

		private void ChangeTranslationClick(object sender, RoutedEventArgs e)
		{
			currentLanguage = (currentLanguage == Language.ENG) ? Language.UKR : Language.ENG;

			foreach (var button in new[] { b1, b2, b3, b4, b5 }) {
				UpdateButtonTranslation(button, currentLanguage);
			}

			if (b6.Content is Viewbox viewbox) {
				if (viewbox.Child is StackPanel stackPanel) {
					if (stackPanel.Children[0] is Image image && stackPanel.Children[1] is TextBlock textBlock) {
						if (currentLanguage == Language.ENG) {
							image.Source = new BitmapImage(new Uri("/res/Images/USAFlag.png", UriKind.Relative));
							textBlock.Text = "ENG";
						} else if (currentLanguage == Language.UKR) {
							image.Source = new BitmapImage(new Uri("/res/Images/UKRFlag.png", UriKind.Relative));
							textBlock.Text = "UKR";
						}
					}
				}
			}
		}

		private void UpdateButtonTranslation(Button button, Language language)
		{
			if (button.Content is Viewbox viewbox) {
				if (viewbox.Child is Label label) {
					string buttonName = button.Name;

					if (buttonTranslations.TryGetValue(buttonName, out Dictionary<Language, string> translations)) {
						if (translations.TryGetValue(language, out string translation)) {
							label.Content = translation;
						}
					}
				}
			}
		}
	}
}
