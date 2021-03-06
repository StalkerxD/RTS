using UnityEngine;
using System.Collections;
using System.Linq;

public class CursorManager : MonoBehaviour, ICursorManager {

	private Cursor[] Cursors;
	private Cursor currentCursor;
	private float cursorSize = 20.0f;
	
	private bool m_ShowCursor = false;
	
	public static CursorManager main;
	
	void Awake()
	{
		main = this;
		Cursor.visible = false;
	}
	
	void Start()
	{	
		Cursor[] temp = GameObject.FindGameObjectWithTag ("Cursors").GetComponents<Cursor>();
       
		Cursors = new Cursor[temp.Length];
		
		foreach (Cursor c in temp)
		{
			Cursors[c.ID] = c;
		}
		
		currentCursor = Cursors[0];
		
		
	}
	
	void Update()
	{
		if (currentCursor.IsAnimated)
		{
			currentCursor.Animate (Time.deltaTime);
		}
	}
	
	public void UpdateCursor(InteractionState interactionState)
	{	
		currentCursor = Cursors[(int)interactionState];		
	}
	
	void OnGUI()
	{
		if (m_ShowCursor)
		{
			GUI.depth = -2;
			//Draw Cursor
			float offset;
			if (currentCursor.CenterTexture)
			{
				offset = cursorSize;
			}
			else
			{
				offset = 0;
			}
			GUI.DrawTexture (new Rect(Input.mousePosition.x-(offset/2), Screen.height-Input.mousePosition.y-(offset/2), cursorSize, cursorSize), currentCursor.GetCursorPicture());
		}
	}
	
	public void HideCursor()
	{
		m_ShowCursor = false;
	}
	
	public void ShowCursor()
	{
		m_ShowCursor = true;
	}
}
