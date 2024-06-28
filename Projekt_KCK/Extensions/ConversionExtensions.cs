using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;

namespace Projekt_KCK.Extensions
{
    public static class ConversionExtensions
    {
        // CPU Conversions
        public static CpuDto ToDto(this Cpu entity)
        {
            return new CpuDto
            {
                Id = entity.Id,
                Model = entity.Model,
                Cores = entity.Cores,
                ClockSpeed = entity.ClockSpeed,
                Socket = entity.Socket
            };
        }

        public static Cpu ToEntity(this CpuDto dto)
        {
            return new Cpu
            {
                Id = dto.Id,
                Model = dto.Model,
                Cores = dto.Cores,
                ClockSpeed = dto.ClockSpeed,
                Socket = dto.Socket
            };
        }

        // GPU Conversions
        public static GpuDto ToDto(this Gpu entity)
        {
            return new GpuDto
            {
                Id = entity.Id,
                Model = entity.Model,
                MemorySize = entity.MemorySize,
                MemoryType = entity.MemoryType,
                CoreClock = entity.CoreClock
            };
        }

        public static Gpu ToEntity(this GpuDto dto)
        {
            return new Gpu
            {
                Id = dto.Id,
                Model = dto.Model,
                MemorySize = dto.MemorySize,
                MemoryType = dto.MemoryType,
                CoreClock = dto.CoreClock
            };
        }

        // PSU Conversions
        public static PsuDto ToDto(this Psu entity)
        {
            return new PsuDto
            {
                Id = entity.Id,
                Model = entity.Model,
                Power = entity.Power,
                EfficiencyRating = entity.EfficiencyRating,
                FormFactor = entity.FormFactor
            };
        }

        public static Psu ToEntity(this PsuDto dto)
        {
            return new Psu
            {
                Id = dto.Id,
                Model = dto.Model,
                Power = dto.Power,
                EfficiencyRating = dto.EfficiencyRating,
                FormFactor = dto.FormFactor
            };
        }

        // CASE Conversions
        public static CaseDto ToDto(this Case entity)
        {
            return new CaseDto
            {
                Id = entity.Id,
                Model = entity.Model,
                FormFactor = entity.FormFactor,
                MaxGPULength = entity.MaxGPULength,
                MaxCPUCoolerHeight = entity.MaxCPUCoolerHeight
            };
        }

        public static Case ToEntity(this CaseDto dto)
        {
            return new Case
            {
                Id = dto.Id,
                Model = dto.Model,
                FormFactor = dto.FormFactor,
                MaxGPULength = dto.MaxGPULength,
                MaxCPUCoolerHeight = dto.MaxCPUCoolerHeight
            };
        }

        // DISK Conversions
        public static DiskDto ToDto(this Disk entity)
        {
            return new DiskDto
            {
                Id = entity.Id,
                Model = entity.Model,
                Capacity = entity.Capacity,
                Type = entity.Type,
                ReadSpeed = entity.ReadSpeed,
                WriteSpeed = entity.WriteSpeed
            };
        }

        public static Disk ToEntity(this DiskDto dto)
        {
            return new Disk
            {
                Id = dto.Id,
                Model = dto.Model,
                Capacity = dto.Capacity,
                Type = dto.Type,
                ReadSpeed = dto.ReadSpeed,
                WriteSpeed = dto.WriteSpeed
            };
        }

        // MOTHERBOARD Conversions
        public static MotherboardDto ToDto(this Motherboard entity)
        {
            return new MotherboardDto
            {
                Id = entity.Id,
                Model = entity.Model,
                FormFactor = entity.FormFactor,
                Socket = entity.Socket,
                RAMSlots = entity.RAMSlots,
                Chipset = entity.Chipset
            };
        }

        public static Motherboard ToEntity(this MotherboardDto dto)
        {
            return new Motherboard
            {
                Id = dto.Id,
                Model = dto.Model,
                FormFactor = dto.FormFactor,
                Socket = dto.Socket,
                RAMSlots = dto.RAMSlots,
                Chipset = dto.Chipset
            };
        }

        // RAM Conversions
        public static RamDto ToDto(this Ram entity)
        {
            return new RamDto
            {
                Id = entity.Id,
                Model = entity.Model,
                Capacity = entity.Capacity,
                Type = entity.Type,
                Speed = entity.Speed
            };
        }

        public static Ram ToEntity(this RamDto dto)
        {
            return new Ram
            {
                Id = dto.Id,
                Model = dto.Model,
                Capacity = dto.Capacity,
                Type = dto.Type,
                Speed = dto.Speed
            };
        }

        // COOLER Conversions
        public static CoolerDto ToDto(this Cooler entity)
        {
            return new CoolerDto
            {
                Id = entity.Id,
                Model = entity.Model,
                Type = entity.Type,
                FanSize = entity.FanSize,
                MaxRPM = entity.MaxRPM
            };
        }

        public static Cooler ToEntity(this CoolerDto dto)
        {
            return new Cooler
            {
                Id = dto.Id,
                Model = dto.Model,
                Type = dto.Type,
                FanSize = dto.FanSize,
                MaxRPM = dto.MaxRPM
            };
        }
    }
}
