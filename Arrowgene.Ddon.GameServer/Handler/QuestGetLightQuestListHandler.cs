using Arrowgene.Ddon.Server;
using Arrowgene.Ddon.Shared.Entity;
using Arrowgene.Ddon.Shared.Entity.PacketStructure;
using Arrowgene.Ddon.Shared.Entity.Structure;
using Arrowgene.Ddon.Shared.Network;
using Arrowgene.Logging;

namespace Arrowgene.Ddon.GameServer.Handler
{
    public class QuestGetLightQuestList : GameStructurePacketHandler<C2SQuestGetLightQuestListReq>
    {
        private static readonly ServerLogger Logger = LogProvider.Logger<ServerLogger>(typeof(QuestGetLightQuestList));
        
        public QuestGetLightQuestList(DdonGameServer server) : base(server)
        {
        }

        public override void Handle(GameClient client, StructurePacket<C2SQuestGetLightQuestListReq> packet)
        {
            S2CQuestGetLightQuestListRes pcap = EntitySerializer.Get<S2CQuestGetLightQuestListRes>().Read(pcap_data);
            
            S2CQuestGetLightQuestListRes res = new S2CQuestGetLightQuestListRes();

            // Spirit Dragon EM
            res.LightQuestList.Add(new CDataLightQuestList()
            {
                Param = new CDataQuestList()
                {
                    QuestScheduleId = 50300010,
                    QuestId = 50300010
                }
            });

            // A Personal Request
            res.LightQuestList.Add(new CDataLightQuestList()
            {
                Param = new CDataQuestList()
                {
                    QuestScheduleId = 40000035,
                    QuestId = 40000035
                }
            });

            client.Send(res);
        }

        private static readonly byte[] pcap_data = new byte[] {
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x1C, 0x00, 0x00, 0x00,  0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x09,
            0x1E, 0x02, 0x66, 0xEE, 0x3A, 0x00, 0x00, 0x00,  0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x27,  0x10, 0x00, 0x00, 0x1F, 0xB4, 0x00, 0x00, 0x00,
            0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x5D, 0xD2, 0xF8, 0x40, 0x00, 0x00, 0x00,  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,  0x00, 0x01, 0x00, 0x00, 0x00, 0x1C, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,  0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x03, 0x01, 0x00, 0x00, 0x00, 0xF9, 0x00,  0x00, 0x00, 0x41, 0x00, 0x00, 0x03, 0xE7, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01,  0x00, 0x01, 0x39, 0x00, 0x00, 0x00, 0x00, 0x3F,
        };
    }
}