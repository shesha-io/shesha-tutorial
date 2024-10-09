using Abp.Domain.Repositories;
using NHibernate.Linq;
using Shesha.Authorization;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shesha.Tutorial.Common.Authorization
{
    /// <summary>
    /// Tutorial Permission checker
    /// </summary>
    public class tutorialPermissionChecker : ICustomPermissionChecker, ItutorialPermissionChecker
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<ShaRoleAppointedPerson, Guid> _rolePersonRepository;
        private readonly IRepository<ShaRoleAppointmentEntity, Guid> _appEntityRepository;

        /// <summary>
        /// Default constructor
        /// </summary>
        public tutorialPermissionChecker(IRepository<Person, Guid> personRepository, IRepository<ShaRoleAppointedPerson, Guid> rolePersonRepository, IRepository<ShaRoleAppointmentEntity, Guid> appEntityRepository)
        {
            _personRepository = personRepository;
            _rolePersonRepository = rolePersonRepository;
            _appEntityRepository = appEntityRepository;
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public async Task<bool> IsGrantedAsync(long userId, string permissionName)
        {
            var person = await _personRepository.GetAll().Where(p => p.User.Id == userId).FirstOrDefaultAsync();
            if (person == null)
                return false;

            if (person.User.UserName.ToLower() == "admin")
                return true;

            switch (permissionName)
            {
                default:
                    return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public bool IsGranted(long userId, string permissionName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// inheritedDoc
        /// </summary>
        /// <param name="person"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<bool> IsInAnyOfRoles(Person person, params string[] roles)
        {
            return await _rolePersonRepository.GetAll()
                .Where(e => roles.Contains(e.Role.Name) && e.Person == person).AnyAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsDataAdministrator(Person person)
        {
            return await IsInAnyOfRoles(person, CommonRoles.DataAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, CommonRoles.SystemAdministrator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> IsGlobalAdmin(Person person)
        {
            return await IsInAnyOfRoles(person, CommonRoles.GlobalAdmin);
        }
        Task<bool> ICustomPermissionChecker.IsGrantedAsync(long userId, string permissionName, EntityReferenceDto<string> permissionedEntity)
        {
            throw new NotImplementedException();
        }

        bool ICustomPermissionChecker.IsGranted(long userId, string permissionName, EntityReferenceDto<string> permissionedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
