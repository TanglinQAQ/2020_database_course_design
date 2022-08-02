<template>
  <div id="deleteteam-container">
     <el-container>
   <el-main>
          <el-table :data="tableData" :default-sort="{ prop: 'date', order: 'descending' }">
            <el-table-column prop="projectname" label="项目名称" width="140">
            </el-table-column>
            <el-table-column prop="originator_id" label="组队发起人" width="140">
            </el-table-column>
            <el-table-column prop="team_type" label="项目类型" width="140">
            </el-table-column>
            <el-table-column prop="region" label="所在校区" width="200">
            </el-table-column>
            <el-table-column prop="details" label="项目简介" width="400">
            </el-table-column>
            <el-table-column prop="date" label="发布时间" sortable>
            </el-table-column>
          </el-table>
        </el-main>
      </el-container>
     </div>
</template>

<script>
import global_msg from '../utils/global.js'
import { getlistInfor } from '@/api/Inforlist.js'
export default {
  name: 'MyProject',
   data() {
    return {
      username: global_msg.nowuserid,
      tableData: [],
    };
  },
   mounted() {
    this.getlist() //页面一进入就加载表格
      },
  methods: {
      getlist() {
      var vm = this;//全局变量
      getlistInfor().then(function (res) {
        global_msg.requirenum = res.data.length;//改变全局requirenum
        // console.log(res);
        // console.log(res.data.length);
        // console.log(res.data[0]);
        // console.log(res.data[0].details);
      
        for (let item of res.data) {
          let form = {//设置添加数据的格式
            projectname: '',
            originator_id: '',
            team_type: '',
            region: '',
            details: '',
            date: '',
          }
       if(item.originator_id=='normal'){
          // console.log(item);
          form.projectname = item.requirement_name;
          form.originator_id = item.originator_id;
          form.team_type = item.team_type;
          form.details = item.details;
          form.date = item.release_time;
          form.date = form.date.replace("\"", "").replace("\"", "");//去掉时间格式的引号
          form.region = item.region;
          vm.tableData.push(form);
          // console.log(form);
          // console.log(vm.tableData)
       }
        }
      })
    }
}
}
</script>

<style>

</style>