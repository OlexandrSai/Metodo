using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Service.Contracts;
using ManutationItemsApp.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.Service.Implementations
{
    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceState State { get; }
        public AssetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            State = new ServiceState();
        }

        public async Task<List<Asset>> GetAllAssetsAsync()
        {
            try
            {
                return await _unitOfWork.AssetRepository.FindAll().ToListAsync();
            }
            catch (Exception ex)
            {

                State.ErrorMessage = ex.Message;
                State.TypeOfError = TypeOfServiceError.ServiceError;
                return null;
            }
        }

        public async Task<ServiceState> RemoveAssetAsync(int id)
        {
            var assetToDelete = await _unitOfWork.AssetRepository.FindByIdAsync(id);
            
            if (assetToDelete==null)
            {
                State.ErrorMessage = "Requested asset not found!";
                State.TypeOfError = TypeOfServiceError.BadRequest;
                return State;
            }

            _unitOfWork.AssetRepository.Delete(assetToDelete);
            await _unitOfWork.CommitAsync();
            return State;
        }

        public async Task<Asset> AddAssetAsync(Asset asset)
        {
            try
            {
                _unitOfWork.AssetRepository.Create(asset);
                await _unitOfWork.CommitAsync();
                return asset;
            }
            catch (Exception)
            {
                State.ErrorMessage = "Requested asset not found!";
                State.TypeOfError = TypeOfServiceError.BadRequest;
                return null;
            }
        }

        public async Task<Asset> EditAssetAsync(Asset asset)
        {
            try
            {
                if (!await AssetExistsAsync(asset.Id))
                {
                    State.ErrorMessage = "Requested asset not found!";
                    State.TypeOfError = TypeOfServiceError.BadRequest;
                    return null;
                }
                _unitOfWork.AssetRepository.Update(asset);
                await _unitOfWork.CommitAsync();
                return asset;
            }
            catch (Exception)
            {
                State.ErrorMessage = "Requested asset not found!";
                State.TypeOfError = TypeOfServiceError.BadRequest;
                return null;
            }
        }

        public async Task<Asset> GetAssetByIdAsync(int id)
        {
            return await _unitOfWork.AssetRepository.FindByIdAsync(id);
        }

        public async Task<bool> AssetExistsAsync(int id)
        {
            return await _unitOfWork.AssetRepository.AssetExists(id);
        }
    }
}
