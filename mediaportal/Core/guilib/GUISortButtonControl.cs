using System;

namespace MediaPortal.GUI.Library
{
	public class GUISortButtonControl : GUIButtonControl
	{
		#region Constructors

		public GUISortButtonControl(int parentId) : base(parentId)
		{
			
		}

		#endregion Constructors

		#region Events

		public event SortEventHandler	SortChanged;

		#endregion Events

		#region Methods

		public override void AllocResources()
		{
			base.AllocResources();

			_sortImages[0].AllocResources();
			_sortImages[1].AllocResources();
			_sortImages[2].AllocResources();
			_sortImages[3].AllocResources();
		}

		public override void FinalizeConstruction()
		{
			base.FinalizeConstruction();

			int x = m_dwPosX + _sortButtonOffsetX;
			int y = m_dwPosY + _sortButtonOffsetY;
			int w = _sortButtonWidth;
			int h = _sortButtonHeight;

			_sortImages[0] = new GUIImage(this.GetID, this.GetID + 25000, x, y, w, h, _ascendingTextureFilename, 0xFFFFFFFF);
			_sortImages[1] = new GUIImage(this.GetID, this.GetID + 25001, x, y, w, h, _ascendingTextureFocusedFilename, 0xFFFFFFFF);
			_sortImages[2] = new GUIImage(this.GetID, this.GetID + 25002, x, y, w, h, _descendingTextureFilename, 0xFFFFFFFF);
			_sortImages[3] = new GUIImage(this.GetID, this.GetID + 25003, x, y, w, h, _descendingTextureFocusedFilename, 0xFFFFFFFF);
		}

		public override void FreeResources()
		{
			base.FreeResources();

			_sortImages[0].FreeResources();
			_sortImages[1].FreeResources();
			_sortImages[2].FreeResources();
			_sortImages[3].FreeResources();
		}

		public override void PreAllocResources()
		{
			base.PreAllocResources();

			_sortImages[0].PreAllocResources();
			_sortImages[1].PreAllocResources();
			_sortImages[2].PreAllocResources();
			_sortImages[3].PreAllocResources();
		}

		public override void Render(float timePassed)
		{
			bool isFocused = this.Focus;

			if(_isSortImageHot)
				m_bHasFocus = false;

			base.Render(timePassed);

			int x = m_dwPosX + _sortButtonOffsetX;
			int y = m_dwPosY + _sortButtonOffsetY;

			if(_sortImages[0].XPosition != x || _sortImages[0].YPosition != y)
				_sortImages[0].SetPosition(x, y);	

			if(_sortImages[1].XPosition != x || _sortImages[1].YPosition != y)
				_sortImages[1].SetPosition(x, y);	

			if(_sortImages[2].XPosition != x || _sortImages[2].YPosition != y)
				_sortImages[2].SetPosition(x, y);	

			if(_sortImages[3].XPosition != x || _sortImages[3].YPosition != y)
				_sortImages[3].SetPosition(x, y);	

			int sortImageIndex = _isAscending ? _isSortImageHot ? 3 : 2 : _isSortImageHot ? 1 : 0;

			_sortImages[sortImageIndex].Render(timePassed);

			m_bHasFocus = isFocused;
		}

		public override bool HitTest(int x, int y, out int controlID, out bool focused)
		{
			bool isHovering = base.HitTest (x, y, out controlID, out focused);

			_isSortImageHot = false;

			if(isHovering && x >= _sortImages[0].XPosition && x <= _sortImages[0].XPosition + _sortImages[0].Width &&
				y >= _sortImages[0].YPosition && y <= _sortImages[0].YPosition + _sortImages[0].Height)
			{
				_isSortImageHot = true;
			}
			
			return isHovering;
		}

		protected override void Update()
		{
			base.Update();

			int x = m_dwPosX + _sortButtonOffsetX;
			int y = m_dwPosY + _sortButtonOffsetY;

			_sortImages[0].SetPosition(x, y);
			_sortImages[1].SetPosition(x, y);
			_sortImages[2].SetPosition(x, y);
			_sortImages[3].SetPosition(x, y);
		}

		public override void OnAction(Action action)
		{
			if(_isSortImageHot && action.wID == Action.ActionType.ACTION_MOUSE_CLICK || action.wID == Action.ActionType.ACTION_SELECT_ITEM && _isSortImageHot)
			{
				_isAscending = !_isAscending;

				if(SortChanged != null)
					SortChanged(this, new SortEventArgs(_isAscending ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending));

				return;
			}
			else if(action.wID == Action.ActionType.ACTION_MOVE_LEFT && _isSortImageHot)
			{
				_isSortImageHot = false;
				return;
			}
			else if(action.wID == Action.ActionType.ACTION_MOVE_RIGHT && _isSortImageHot == false)
			{
				_isSortImageHot = true;
				return;
			}

			base.OnAction(action);
		}

		public override bool OnMessage(GUIMessage message)
		{
			if(message.Message == GUIMessage.MessageType.GUI_MSG_SETFOCUS || message.Message == GUIMessage.MessageType.GUI_MSG_LOSTFOCUS)
				_isSortImageHot = false;

			return base.OnMessage (message);
		}

		#endregion Methods

		#region Properties

		public bool IsAscending
		{
			get { return _isAscending; }
			set { _isAscending = value; }
		}

		#endregion Properties

		#region Fields

		[XMLSkinElement("textureAscending")]
		string						_ascendingTextureFilename = "arrow_round_up_nofocus.png";

		[XMLSkinElement("textureAscendingFocused")]
		string						_ascendingTextureFocusedFilename = "arrow_round_up_focus.png";

		[XMLSkinElement("textureDescending")]
		string						_descendingTextureFilename = "arrow_round_down_nofocus.png";

		[XMLSkinElement("textureDescendingFocused")]
		string						_descendingTextureFocusedFilename = "arrow_round_down_focus.png";

		bool						_isAscending = true;
		bool						_isSortImageHot = false;

		[XMLSkinElement("offsetSortButtonX")]
		int							_sortButtonOffsetX = 0;
		
		[XMLSkinElement("offsetSortButtonY")]
		int							_sortButtonOffsetY = 0;

		[XMLSkinElement("offsetSortButtonHeight")]
		int							_sortButtonHeight = 0;

		[XMLSkinElement("offsetSortButtonWidth")]
		int							_sortButtonWidth = 0;
	
		GUIImage[]					_sortImages = new GUIImage[4];

		#endregion Fields
	}
}
