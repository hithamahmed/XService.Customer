using Application.XIdentity.Core.DTO;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using Documents.Tracker.Core.DTO.Consumers;
using General.App.Consumers.Core;
using ManageFiles.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    internal class ConsumersServices : MapperCore, IQueryConsumersServices, ICommandConsumerServices
    {
        private readonly IConsumersCore consumersProfileCore;
        private readonly IServiceRequiredDocumentsCore _serviceRequiredDocumentsCore;
        private readonly IManageFilesCore _manageFilesCore;
        //private readonly IConsumerAddress consumersAddressCore;

        public ConsumersServices(
            IServiceRequiredDocumentsCore serviceRequiredDocumentsCore,
            IManageFilesCore manageFilesCore,
            IConsumersCore _consumersProfileCore
            )
        {
            
            _serviceRequiredDocumentsCore = serviceRequiredDocumentsCore;
            _manageFilesCore = manageFilesCore;
            consumersProfileCore = _consumersProfileCore;
        }


        public async Task<ICollection<ConsumerAddressOTO>> GetAllConsumerAddressesByConsumerId(string consumerId)
        {
            try
            {
                var x = await consumersProfileCore.GetAllConsumerAddresses(consumerId);
                return Mapper.Map<ICollection<ConsumerAddressOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<ConsumerOTO>> GetAllConsumers()
        {
            try
            {
                var x = await consumersProfileCore.GetAllConsumers();
                return Mapper.Map<ICollection<ConsumerOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ConsumerAddressOTO> GetSingleConsumerAddressByAddressId(int ConsumersAddressId)
        {
            try
            {
                var x = await consumersProfileCore.GetConsumerAddressById(ConsumersAddressId);
                return Mapper.Map<ConsumerAddressOTO>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ConsumerOTO> GetSingleConsumerByConusmerId(string conusmerId)
        {
            try
            {
                var x = await consumersProfileCore.GetConsumerByKey(conusmerId);
                return Mapper.Map<ConsumerOTO>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ConsumersProfileOTO> GetSingleConsumerWithAddressByConsumerId(string consumerId)
        {
            ConsumersProfileOTO manageAppConsumerDTO = new ConsumersProfileOTO();
            try
            {
                var x = await GetSingleConsumerByConusmerId(consumerId);
                manageAppConsumerDTO.Consumer = Mapper.Map<ConsumerOTO>(x);

                var ConsumAddresses = await GetAllConsumerAddressesByConsumerId(consumerId);

                manageAppConsumerDTO.AppConsumerAddresses = ConsumAddresses;
                return manageAppConsumerDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SetDefaultConsumerAddressByAddressId(int ConsumersAddressId)
        {
            try
            {
                return await consumersProfileCore.SetConsumerAddressAsDefault(ConsumersAddressId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<int> SetEnableDisableConsumerByConusmerId(int conusmerId)
        //{
        //    try
        //    {
        //        return await consumersProfileCore.EnableDisableConsumer(conusmerId);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<int> AddOrEditConsumerAddressByConsumer(ConsumerAddressOTO Consumer)
        {
            try
            {
                var x = Mapper.Map<ConsumerAddressDTO>(Consumer);
                return await consumersProfileCore.AddEditConsumerAddress(x);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<int> EditConsumerProfile(ConsumerOTO conusmer)
        {
            try
            {
                var x = Mapper.Map<ConsumerDTO>(conusmer);
                return await consumersProfileCore.EditConsumerProfile(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<ConsumerProductDocumentFileOTO>> GetConsumerProductAttachmentFiles(string consumerId, int ProductId)
        {
            try
            {
                var consumerFiles = await _manageFilesCore.GetAttachmentsFiles(consumerId);
                var productRequiredDocs = await _serviceRequiredDocumentsCore.GetRequiredDocuments(ProductId);
                List<ConsumerProductDocumentFileOTO> consumerProductDocumentFiles = new List<ConsumerProductDocumentFileOTO>();

                foreach (var doc in productRequiredDocs)
                {
                    var consumerFile = consumerFiles
                        .Where(x => x.ReferenceTypeId == doc.RefId)
                        .Select(x => x).FirstOrDefault();
                    var consumerProductFile = Mapper.Map<ConsumerAttachmentFileOTO>(consumerFile);
                    var filepathUri = await _manageFilesCore.GetFileUri(consumerId, doc.RefId);

                    consumerProductDocumentFiles.Add(new ConsumerProductDocumentFileOTO
                    {
                        ConsumerFiles = consumerProductFile,
                        ProductDocuments = doc,
                        FilePathUrl = filepathUri == null ? "" : filepathUri
                    }); ;
                }

                return consumerProductDocumentFiles;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<ConsumerAttachmentFileOTO>> GetConsumerAttachmentFiles(string consumerId)
        {
            try
            {
                var consumerFiles = await _manageFilesCore.GetAttachmentsFiles(consumerId);
                var consumerProductFile = Mapper.Map<ICollection<ConsumerAttachmentFileOTO>>(consumerFiles);
                //var productRequiredDocs = await _serviceRequiredDocumentsCore.GetRequiredDocuments(ProductId);
                //List<ConsumerProductDocumentFileOTO> consumerProductDocumentFiles = new List<ConsumerProductDocumentFileOTO>();

                //foreach (var doc in productRequiredDocs)
                //{
                //    var consumerFile = consumerFiles
                //        .Where(x => x.ReferenceTypeId == doc.RefId)
                //        .Select(x => x).FirstOrDefault();
                //    var consumerProductFile = Mapper.Map<ConsumerAttachmentFileOTO>(consumerFile);
                //    var filepathUri = await _manageFilesCore.GetFileUri(consumerId, doc.RefId);

                //    consumerProductDocumentFiles.Add(new ConsumerProductDocumentFileOTO
                //    {
                //        ConsumerFiles = consumerProductFile,
                //        ProductDocuments = doc,
                //        FilePathUrl = filepathUri == null ? "" : filepathUri
                //    }); ;
                //}

                return consumerProductFile;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
