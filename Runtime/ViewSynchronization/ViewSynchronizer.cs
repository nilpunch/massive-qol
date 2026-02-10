namespace Massive.QoL
{
	public class ViewSynchronizer<TView> where TView : IEntityView
	{
		private readonly DataSet<ViewInstance<TView>> _viewInstances = new DataSet<ViewInstance<TView>>();
		private readonly World _world;
		private readonly IViewFactory<TView> _viewFactory;

		public ViewSynchronizer(World world, IViewFactory<TView> viewFactory)
		{
			_world = world;
			_viewFactory = viewFactory;
		}

		public void SynchronizeAll()
		{
			var viewAssets = _world.DataSet<ViewAsset>();

			foreach (var id in _viewInstances)
			{
				var viewInstance = _viewInstances.Get(id);
				if (!viewAssets.Has(id) || !viewAssets.Get(id).Equals(viewInstance.Asset))
				{
					RemoveViewInstance(id, viewInstance);
				}
			}

			foreach (var id in viewAssets)
			{
				var viewAsset = viewAssets.Get(id);
				if (!_viewInstances.Has(id))
				{
					AssignViewInstance(viewAsset, id);
				}
			}
		}

		public void SynchronizeSingle(int entityId)
		{
			var viewAsset = _world.Get<ViewAsset>(entityId);

			if (_viewInstances.Has(entityId))
			{
				var viewInstance = _viewInstances.Get(entityId);

				// If instance is alright, nothing to be done
				if (viewInstance.Asset.Equals(viewAsset))
				{
					return;
				}
				else
				{
					RemoveViewInstance(entityId, viewInstance);
				}
			}

			AssignViewInstance(viewAsset, entityId);
		}

		public void DestroyView(int entityId)
		{
			if (_viewInstances.Has(entityId))
			{
				RemoveViewInstance(entityId, _viewInstances.Get(entityId));
			}
		}

		private void AssignViewInstance(ViewAsset viewAsset, int entityId)
		{
			var view = _viewFactory.CreateView(viewAsset);

			view.AssignEntity(_world.GetEntity(entityId));

			_viewInstances.Set(entityId, new ViewInstance<TView>() { Instance = view, Asset = viewAsset });
		}

		private void RemoveViewInstance(int entityId, ViewInstance<TView> viewInstance)
		{
			viewInstance.Instance.RemoveEntity();

			_viewFactory.DestroyView(viewInstance.Instance);

			_viewInstances.Remove(entityId);
		}
	}
}
