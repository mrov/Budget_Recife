const options: Highcharts.Options = {
  chart: {
    type: 'column',
    backgroundColor: {
      linearGradient: { x1: 0, x2: 0, y1: 0, y2: 1 },
      stops: [
        [0, 'rgba(0,0,0,1)'],
        [1, 'rgba(66,0,140,1)'],
        [2, 'rgba(66,0,140,1)'],
      ],
    },
    style: {
      fontFamily: 'Helvetica, Arial, sans-serif',
      fontWeight: "100"
    },
  },
  subtitle: {
    text: 'Source: http://dados.recife.pe.gov.br/dataset/despesas-orcamentarias',
  },
  xAxis: {},
  yAxis: {
    title: {
      text: 'Valor liquido total',
    },
  },
  tooltip: {
    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
    pointFormat:
      '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
      '<td style="padding:0"><b>{point.y:.2f}</b></td></tr>',
    footerFormat: '</table>',
    shared: true,
    useHTML: true,
  },

  plotOptions: {
    column: {
      pointPadding: 0.2,
      borderWidth: 0,
    },
  },
  series: [],
};

export { options };
