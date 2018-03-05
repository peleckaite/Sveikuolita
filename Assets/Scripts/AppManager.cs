using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
	public GameObject menuScreen;
	public GameObject currentScreen;
	public GameObject canvas;

	public struct ScrollItem
	{
		public string title;
		public string body;
		public string spriteName;
		public Sprite sprite;
	}

	ScrollItem [] ScrollItems = new ScrollItem[]
	{
		new ScrollItem { title = "Atidaryta nauja kineziterapijos \nsalė!", 
			body = "2018-03-05 atidaryta nauja kineziterapijos salė. Kviečiame apsilankyti!", 
			spriteName = "1img"
		},
		new ScrollItem { title = "Subalansuotos mitybos planai", 
			body = "Tai unikali sistema, kuri kartu su profesionalų komanda padės susikurti norimas kūno linijas", 
			spriteName = "2img"
		},
		new ScrollItem { title = "Nemokamos bėgimo treniruotės", 
			body = "Prasideda nemokamos šeštadienio bėgimo treniruotės. Registruokitės!", 
			spriteName = "3img"
		},
		new ScrollItem { title = "Sportuok namuose!", 
			body = "Individualių programų sudarymas sportui namuose", 
			spriteName = "4img"
		}
	};

	void LoadResources()
	{
		for (int i = 0; i < ScrollItems.Length; i++)
		{
			var e = ScrollItems[i];          
			var txt2d = Resources.Load(e.spriteName) as Texture2D;

			e.sprite = Sprite.Create(
				txt2d, 
				new Rect(0, 0, txt2d.width, txt2d.height), 
				new Vector2(0, 0));
			ScrollItems[i] = e;  
		}
		print(ScrollItems[0].sprite == null);
	}

	void SetCameraScreenValues()
	{
		Transform scrollViewContent = canvas.transform.Find("CameraScreen/Scroll View/Viewport/Content");
		print(scrollViewContent == null);
		for (int i = 0; i < 4; i++)
		{
			Transform item = scrollViewContent.Find("Item ("+i+")");
			item.Find("Title").GetComponent<Text>().text = ScrollItems[i].title;
			item.Find("BodyContent/BodyText").GetComponent<Text>().text = ScrollItems[i].body;
			item.Find("Image").GetComponent<Image>().sprite = ScrollItems[i].sprite;
		}
	}


	void Start()
	{
		menuScreen = currentScreen;

		LoadResources();
		SetCameraScreenValues();

	}

	#region On Button Click receivers
	public void CallPhone(Object obj)
	{
		var phoneTxt = (obj as GameObject).GetComponent<Text>().text;
		Application.OpenURL("tel://" + phoneTxt);
		//todo kontaktu suvedimas is listo
	}

	public void BackButtonClick()
	{
		SwitchScreen(menuScreen);
	}

	public void MenuButtonClick(Object screenToAcivate)
	{
		GameObject screen = screenToAcivate as GameObject;
		SwitchScreen(screen);
	}
	#endregion

	void SwitchScreen(GameObject screen)
	{
		if (currentScreen != null)  
		{ 
			currentScreen.SetActive(false);
		}

		screen.SetActive(true);
		currentScreen = screen;
	}
}
