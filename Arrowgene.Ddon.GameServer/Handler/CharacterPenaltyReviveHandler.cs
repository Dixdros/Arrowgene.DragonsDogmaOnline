using Arrowgene.Buffers;
using Arrowgene.Ddon.Server;
using Arrowgene.Ddon.Server.Network;
using Arrowgene.Ddon.Shared.Entity;
using Arrowgene.Ddon.Shared.Entity.PacketStructure;
using Arrowgene.Ddon.Shared.Network;
using Arrowgene.Logging;

namespace Arrowgene.Ddon.GameServer.Handler
{
    public class CharacterPenaltyReviveHandler : PacketHandler<GameClient>
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(CharacterPenaltyReviveHandler));

        public CharacterPenaltyReviveHandler(DdonGameServer server) : base(server)
        {
        }

        public override PacketId Id => PacketId.C2S_CHARACTER_CHARACTER_PENALTY_REVIVE_REQ;

        public override void Handle(GameClient client, Packet packet)
        {
            // Read request
            C2SCharacterPenaltyReviveReq req = EntitySerializer.Get<C2SCharacterPenaltyReviveReq>().Read(packet.AsBuffer());
            
            // Send response
            IBuffer resBuffer = new StreamBuffer();
            resBuffer.WriteInt32(0, Endianness.Big); // error
            resBuffer.WriteInt32(0, Endianness.Big); // result

            S2CCharacterPenaltyReviveRes res = new S2CCharacterPenaltyReviveRes();

            EntitySerializer.Get<S2CCharacterPenaltyReviveRes>().Write(resBuffer, res);
            Packet resPacket = new Packet(PacketId.S2C_CHARACTER_CHARACTER_PENALTY_REVIVE_RES, resBuffer.GetAllBytes());
            client.Send(resPacket);
        }
    }
}