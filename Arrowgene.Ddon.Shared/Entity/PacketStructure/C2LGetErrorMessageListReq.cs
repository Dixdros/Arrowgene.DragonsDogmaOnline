using Arrowgene.Buffers;

namespace Arrowgene.Ddon.Shared.Entity.PacketStructure
{
    public class C2LGetErrorMessageListReq : IPacketStructure
    {
        public PacketId Id => PacketId.C2L_GET_ERROR_MESSAGE_LIST_REQ;
    }

    public class C2LGetErrorMessageListReqSerializer : EntitySerializer<C2LGetErrorMessageListReq>
    {
        public override void Write(IBuffer buffer, C2LGetErrorMessageListReq obj)
        {
        }

        public override C2LGetErrorMessageListReq Read(IBuffer buffer)
        {
            return new C2LGetErrorMessageListReq();
        }
    }
}