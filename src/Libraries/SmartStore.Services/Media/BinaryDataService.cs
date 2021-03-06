﻿using SmartStore.Core.Data;
using SmartStore.Core.Domain.Media;
using SmartStore.Core.Events;

namespace SmartStore.Services.Media
{
	public class BinaryDataService : IBinaryDataService
	{
		private readonly IRepository<BinaryData> _binaryDataRepository;
		private readonly IEventPublisher _eventPublisher;

		public BinaryDataService(
			IRepository<BinaryData> binaryDataRepository,
			IEventPublisher eventPublisher)
		{
			_binaryDataRepository = binaryDataRepository;
			_eventPublisher = eventPublisher;
		}

		public virtual void DeleteBinaryData(BinaryData binaryData, bool publishEvent = true)
		{
			if (binaryData != null)
			{
				_binaryDataRepository.Delete(binaryData);

				if (publishEvent)
				{
					_eventPublisher.EntityDeleted(binaryData);
				}
			}
		}

		public virtual void UpdateBinaryData(BinaryData binaryData, bool publishEvent = true)
		{
			Guard.ArgumentNotNull(() => binaryData);

			_binaryDataRepository.Update(binaryData);

			if (publishEvent)
			{
				_eventPublisher.EntityUpdated(binaryData);
			}
		}

		public virtual void InsertBinaryData(BinaryData binaryData, bool publishEvent = true)
		{
			Guard.ArgumentNotNull(() => binaryData);

			_binaryDataRepository.Insert(binaryData);

			if (publishEvent)
			{
				_eventPublisher.EntityInserted(binaryData);
			}
		}

		public virtual BinaryData GetBinaryDataById(int id)
		{
			if (id == 0)
				return null;

			return _binaryDataRepository.GetById(id);
		}
	}
}
