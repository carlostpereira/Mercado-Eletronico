using System;

namespace MercadoEletronico.Shared.Entities
{
    public abstract class Entity
    {

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

    }
}
